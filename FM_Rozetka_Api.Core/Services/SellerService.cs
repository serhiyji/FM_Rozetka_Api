using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Company;
using FM_Rozetka_Api.Core.DTOs.Seller;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications;
using FM_Rozetka_Api.Core.Specifications.Seller;
using Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FM_Rozetka_Api.Core.Services
{
    public class SellerService : ISellerService
    {
        private readonly IRepository<SellerApplication> _sellerRepository;
        private readonly IMapper _mapper;
        private readonly EmailService _emailService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICompanyService _comapntService;
        public SellerService(IRepository<SellerApplication> sellerRepository, IMapper mapper, EmailService emailService, UserManager<AppUser> userManager, ICompanyService comapntService)
        {
            _sellerRepository = sellerRepository;
            _mapper = mapper;
            _emailService = emailService;
            _userManager = userManager;
            _comapntService = comapntService;
        }

        public async Task<IEnumerable<SellerApplicationDTO>> GetAllApplicationsAsync()
        {
            var applications = await _sellerRepository.GetAll();
            return _mapper.Map<IEnumerable<SellerApplicationDTO>>(applications);
        }

        public async Task<IEnumerable<SellerApplicationDTO>> GetAllActivityApplicationsAsync()
        {
            var applications = await _sellerRepository.GetListBySpec(new SellerTokenSpecification.GetAllActivityApplications());

            if (applications == null)
            {
                return Enumerable.Empty<SellerApplicationDTO>();
            }

            return _mapper.Map<IEnumerable<SellerApplicationDTO>>(applications);
        }


        public async Task<SellerApplicationDTO> GetApplicationByIdAsync(int id)
        {
            var application = await _sellerRepository.GetByID(id);
            return _mapper.Map<SellerApplicationDTO>(application);
        }

        public async Task<SellerApplication> AddApplicationAsync(CreateSellerApplicationDTO application)
        {
            var sellerApplication = _mapper.Map<SellerApplication>(application);
            await _sellerRepository.Insert(sellerApplication);
            await _sellerRepository.Save();
            return sellerApplication;
        }

        public async Task UpdateApplicationStatusAsync(SellerApplicationDTO application)
        {
            UpdateApplicationAsync(_mapper.Map<UpdateSellerApplicationDTO>(application));

            if (application.IsApproved)
            {
                var newComapny = new CreateCompanyDTO 
                {
                    Name = application.CompanyName,
                    PhoneNumber = application.PhoneNumber
                };
                var company = await _comapntService.AddApplicationAsync(newComapny);

                var user = await _userManager.FindByEmailAsync(application.Email);
                if (user != null && company != null)
                {
                    // Якщо користувач вже зареєстрований, надсилаємо повідомлення про успішну реєстрацію магазину
                    string emailBody = $"<h1>Your store has been successfully registered.</h1>";
                    await _emailService.SendEmailAsync(application.Email, "Store Registration Successful", emailBody);

                    user.CompanyId = company.Id;

                    await _userManager.UpdateAsync(user);

                    await _userManager.AddToRoleAsync(user, "Seller");
                }
                else
                {
                    string fullName = application.FullName;
                    string[] nameParts = fullName.Split(new char[] { ' ' }, 2); // Розділяємо лише на перше пробілове місце

                    string firstName = nameParts[0];
                    string lastName = nameParts.Length > 1 ? nameParts[1] : "";
                    // Якщо користувача немає, створюємо його і надсилаємо посилання для підтвердження реєстрації
                    user = new AppUser
                    {
                        Email = application.Email,
                        UserName = application.Email,
                        EmailConfirmed = false,
                        FirstName = firstName,
                        LastName = lastName,
                        CompanyId = company.Id,
                        PhoneNumber=application.PhoneNumber,
                    };

                    var result = await _userManager.CreateAsync(user);
                    if (!result.Succeeded)
                    {
                        throw new Exception("Failed to create user.");
                    }

                    // Далі генеруємо токен для підтвердження реєстрації
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

                    // Формуємо посилання для підтвердження реєстрації
                    string url = $"http://localhost:5173/registerCompany?email={application.Email}&companyName={application.CompanyName}&phoneNumber={application.PhoneNumber}&token={encodedToken}";
                    string emailBody = $"<h1>Confirm your email please.</h1><a href='{url}'>Confirm now</a>";

                    // Надсилаємо електронний лист з посиланням на підтвердження реєстрації
                    await _emailService.SendEmailAsync(application.Email, "Confirm your email", emailBody);

                }
            }
        }



        public async Task UpdateApplicationAsync(UpdateSellerApplicationDTO application)
        {
            var sellerApplication = _mapper.Map<SellerApplication>(application);
            await _sellerRepository.Update(sellerApplication);
            await _sellerRepository.Save();
        }

        public async Task DeleteApplicationAsync(int id)
        {
            await _sellerRepository.Delete(id);
            await _sellerRepository.Save();
        }

       
    }
}
