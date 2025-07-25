﻿using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Company;
using FM_Rozetka_Api.Core.DTOs.Seller;
using FM_Rozetka_Api.Core.DTOs.Shops.Shop;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace FM_Rozetka_Api.Core.Services
{
    internal class SellerService : ISellerService
    {
        private readonly IRepository<SellerApplication> _sellerRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICompanyService _comapntService;
        private readonly IShopService _shopService;
        private readonly IConfiguration _configuration;

        public SellerService(IRepository<SellerApplication> sellerRepository, IConfiguration configuration, IShopService shopService, IMapper mapper, IEmailService emailService, UserManager<AppUser> userManager, ICompanyService comapntService)
        {
            _sellerRepository = sellerRepository;
            _mapper = mapper;
            _emailService = emailService;
            _userManager = userManager;
            _comapntService = comapntService;
            _shopService = shopService;
            _configuration = configuration;
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
                    var newShop = _mapper.Map<ShopCreateDTO>(application);
                    newShop.AppUserId = user.Id;
                    newShop.CompanyId = company.Id;
                    await _shopService.AddAsync(newShop);

                    // Якщо користувач вже зареєстрований, надсилаємо повідомлення про успішну реєстрацію магазину
                    string emailBody = $"<h1>Your store has been successfully registered.</h1>";
                    await _emailService.SendEmailAsync(application.Email, "Store Registration Successful", emailBody);

                   

                    await _userManager.UpdateAsync(user);

                    // Оновлюємо роль користувача на "Seller"
                    var currentRoles = await _userManager.GetRolesAsync(user);
                    if (currentRoles.Any())
                    {
                        await _userManager.RemoveFromRolesAsync(user, currentRoles);
                    }
                    await _userManager.AddToRoleAsync(user, "Seller");
                }
                else
                {
                    string fullName = application.FullName;
                    string[] nameParts = fullName.Split(new char[] { ' ' }, 2);

                    string firstName = nameParts[0];
                    string lastName = nameParts.Length > 1 ? nameParts[1] : "";
                    
                    user = new AppUser
                    {
                        Email = application.Email,
                        UserName = application.Email,
                        EmailConfirmed = false,
                        FirstName = firstName,
                        LastName = lastName,
                        PhoneNumber=application.PhoneNumber,
                        
                    };
                    var password = Utility.GenerateRandomPassword(); 
                    var result = await _userManager.CreateAsync(user, password);

                    if (!result.Succeeded)
                    {
                        throw new Exception("Failed to create user.");
                    }

                    var userToShop = await _userManager.FindByEmailAsync(user.Email);

                    var newShop = _mapper.Map<ShopCreateDTO>(application);
                    newShop.AppUserId = userToShop.Id;
                    newShop.CompanyId = company.Id;
                    await _shopService.AddAsync(newShop);

                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var encodedToken = Encoding.UTF8.GetBytes(token);
                    var validEmailToken = WebEncoders.Base64UrlEncode(encodedToken);

                    string url = $"{_configuration["HostSettings:URL"]}/confirmemail?userid={user.Id}&token={validEmailToken}";
                    string emailBody = $"" +
                        $"<h1>Confirm your email please.</h1><hr><h2>You password: {password}</h2><a href='{url}'>Confirm now</a>";
                    await _emailService.SendEmailAsync(user.Email, "Confirm your email", emailBody);

                    await _userManager.AddToRoleAsync(user, "Seller");
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

        public async Task<ServiceResponse<int, object>> GetAppCountAsync()
        {
            try
            {
                var applications = await _sellerRepository.GetListBySpec(new SellerTokenSpecification.GetAllActivityApplications());
                int applicationCount = applications.Count();

                return new ServiceResponse<int, object>(true, "Application count retrieved successfully", payload: applicationCount);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error retrieving Application count: {ex.Message}");
                return new ServiceResponse<int, object>(false, "Error retrieving Application count");
            }
        }
    }
}
