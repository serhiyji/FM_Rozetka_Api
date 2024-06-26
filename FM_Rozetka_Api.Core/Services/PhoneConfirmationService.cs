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
        public PhoneConfirmationService(IRepository<PhoneConfirmation> phoneConfirmationRepo, UserManager<AppUser> userManager)
        {
            _phoneConfirmationRepo = phoneConfirmationRepo;
            _userManager = userManager;
        }

        public async Task CreateConfirmPhone(CreateConfirmPhoneDto model)
        {
            PhoneConfirmation res = await _phoneConfirmationRepo.GetItemBySpec(new PhoneConfirmationSpecification.GetByAppUserId(model.AppUserId));
            if (res == null)
            {
                await this.Create(model.AppUserId, model.Phone);
            }
            else
            {
                if (DateTime.UtcNow > res.CreateTime.AddMinutes(3))
                {
                    await _phoneConfirmationRepo.Delete(res.Id);
                    await _phoneConfirmationRepo.Save();
                    await this.Create(model.AppUserId, model.Phone);
                }
            }
        }

        private async Task Create(string AppUserId, string Phone)
        {
            PhoneConfirmation phoneConfirmation = new PhoneConfirmation()
            {
                CreateTime = DateTime.UtcNow,
                AppUserId = AppUserId,
                Phone = Phone,
                Code = GenerateRandomNumbers()
            };
            await _phoneConfirmationRepo.Insert(phoneConfirmation);
            await _phoneConfirmationRepo.Save();

        }

        private async Task SendToAllMessages(string phone, string code)
        {

        }

        public async Task<ServiceResponse> ConfirmPhone(ConfirmPhoneDto model)
        {
            AppUser user = await _userManager.FindByIdAsync(model.AppUserId);
            if (user == null)
            {
                return new ServiceResponse(false, "User not found");
            }
            PhoneConfirmation phoneConfirmation = await _phoneConfirmationRepo.GetItemBySpec(new PhoneConfirmationSpecification.GetByAppUserId(model.AppUserId));
            if (phoneConfirmation == null)
            {
                return new ServiceResponse(false, "Phone Confirmation not found");
            }
            if(DateTime.UtcNow > phoneConfirmation.CreateTime.AddMinutes(3))
            {
                await _phoneConfirmationRepo.Delete(phoneConfirmation.Id);
                await _phoneConfirmationRepo.Save();
                return new ServiceResponse(false, "Please reload your phone verification code");
            }
            if (phoneConfirmation.Code == model.Code)
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
