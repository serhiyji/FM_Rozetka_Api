using FM_Rozetka_Api.Core.DTOs.PhoneConfirmation;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications;
using Microsoft.AspNetCore.Identity;
using System.Text;

namespace FM_Rozetka_Api.Core.Services
{
    public class PhoneConfirmationService : IPhoneConfirmationService
    {
        private readonly IRepository<PhoneConfirmation> _phoneConfirmationRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITelegramUserService _telegramUserService;
        private readonly ITelegramApiHandlerService _telegramApiHandlerService;
        public PhoneConfirmationService
            (
                IRepository<PhoneConfirmation> phoneConfirmationRepo, 
                UserManager<AppUser> userManager, 
                ITelegramUserService telegramUserService,
                ITelegramApiHandlerService telegramApiHandlerService
            )
        {
            _phoneConfirmationRepo = phoneConfirmationRepo;
            _userManager = userManager;
            _telegramUserService = telegramUserService;
            _telegramApiHandlerService = telegramApiHandlerService;
        }

        public async Task<ServiceResponse> CreateConfirmPhone(CreateConfirmPhoneDto model)
        {
            AppUser appUser = await _userManager.FindByIdAsync(model.userid);
            if (appUser == null && appUser.PhoneNumberConfirmed == true && appUser.PhoneNumber == model.phoneNumber)
            {
                return new ServiceResponse(false, "Цей номер телефону вже був підтверджений");
            }
            PhoneConfirmation res = await _phoneConfirmationRepo.GetItemBySpec(new PhoneConfirmationSpecification.GetByAppUserId(model.userid));
            if (res == null)
            {
                await this.Create(model.userid, model.phoneNumber);
                return new ServiceResponse(true, "Код підтвердження був надісланий");
            }
            else
            {
                if (DateTime.UtcNow > res.CreateTime.AddMinutes(5))
                {
                    await _phoneConfirmationRepo.Delete(res.Id);
                    await _phoneConfirmationRepo.Save();
                    await this.Create(model.userid, model.phoneNumber);
                    return new ServiceResponse(true, "Код підтвердження був надісланий");
                }
                return new ServiceResponse(false, "Час з минулого запиту (5хв) не прийшов");
            }
        }

        private async Task Create(string AppUserId, string Phone)
        {
            PhoneConfirmation phoneConfirmation = new PhoneConfirmation()
            {
                CreateTime = DateTime.UtcNow,
                AppUserId = AppUserId,
                Phone = TelegramUserService.RemovePlusSign(Phone),
                Code = GenerateRandomNumbers()
            };
            await _phoneConfirmationRepo.Insert(phoneConfirmation);
            await _phoneConfirmationRepo.Save();

            // telegram
            bool IsNumberEx = await _telegramUserService.IsNumberInTelegramUsers(Phone);
            if (IsNumberEx)
            {
                bool IsSendTelegram = await _telegramApiHandlerService.SendConfirmationCodeForPhone(Phone, phoneConfirmation.Code);
                if(IsSendTelegram)
                {
                    phoneConfirmation.IsSendInTelegram = true;
                    await _phoneConfirmationRepo.Update(phoneConfirmation);
                    await _phoneConfirmationRepo.Save();
                }
            }
        }


        public async Task<ServiceResponse> ConfirmPhone(ConfirmPhoneDto model)
        {
            AppUser user = await _userManager.FindByIdAsync(model.userid);
            if (user == null)
            {
                return new ServiceResponse(false, "User not found");
            }
            PhoneConfirmation phoneConfirmation = await _phoneConfirmationRepo.GetItemBySpec(new PhoneConfirmationSpecification.GetByAppUserId(model.userid));
            if (phoneConfirmation == null)
            {
                return new ServiceResponse(false, "Phone Confirmation not found");
            }
            if(DateTime.UtcNow > phoneConfirmation.CreateTime.AddMinutes(5))
            {
                await _phoneConfirmationRepo.Delete(phoneConfirmation.Id);
                await _phoneConfirmationRepo.Save();
                return new ServiceResponse(false, "Please reload your phone verification code");
            }
            if (phoneConfirmation.Code == model.confirmationCode)
            {

                string token = await _userManager.GenerateChangePhoneNumberTokenAsync(user, phoneConfirmation.Phone);
                IdentityResult result = await _userManager.ChangePhoneNumberAsync(user, phoneConfirmation.Phone, token);

                if (result.Succeeded)
                {
                    await _phoneConfirmationRepo.Delete(phoneConfirmation.Id);
                    await _phoneConfirmationRepo.Save();

                    return new ServiceResponse(true, "Success");
                }
                return new ServiceResponse(false, "Something went wrong");
            }
            return new ServiceResponse(false, "Code not true");
        }

        private static string GenerateRandomNumbers(int count = 6)
        {
            var random = new Random();
            var result = new StringBuilder(count);
            for (int i = 0; i < count; i++)
            {
                result.Append(random.Next(0, 10));
            }
            return result.ToString();
        }
    }
}
