using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Shops;
using FM_Rozetka_Api.Core.DTOs.Shops.ModeratorShop;
using FM_Rozetka_Api.Core.DTOs.Shops.Shop;
using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications.Shops;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeratorShopDTO = FM_Rozetka_Api.Core.DTOs.Shops.ModeratorShop.ModeratorShopDTO;

namespace FM_Rozetka_Api.Core.Services
{
    public class ModeratorShopService : IModeratorShopService
    {
        private readonly IRepository<ModeratorShop> _moderatorShopRepository;
        private readonly IMapper _mapper;

        private readonly IShopService _shopService;

        private readonly UserManager<AppUser> _userManager;
        private readonly EmailService _emailService;


        public ModeratorShopService(IRepository<ModeratorShop> moderatorShopRepository,IMapper mapper, IShopService shopService, UserManager<AppUser> userManager, EmailService emailService)
        {
            _moderatorShopRepository = moderatorShopRepository;
            _mapper = mapper;
            _shopService = shopService;

            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<ServiceResponse<ModeratorShop, object>> AddAsync(ModeratorShopCreateDTO model)
        {
            var shop = await _shopService.GetByIdAsync(model.ShopId);
            if (shop == null)
            {
                return new ServiceResponse<ModeratorShop, object>(false, "Shop not found");
            }

            var user = await _userManager.FindByIdAsync(model.AppUserId);
            if (user == null)
            {
                return new ServiceResponse<ModeratorShop, object>(false, "User not found");
            }
            var moderatorShop = _mapper.Map<ModeratorShop>(model);
            await _moderatorShopRepository.Insert(moderatorShop);
            await _moderatorShopRepository.Save();
            return new ServiceResponse<ModeratorShop, object>(true, "Succes", payload: moderatorShop);
        }

        public async Task DeleteAsync(int id)
        {
            await _moderatorShopRepository.Delete(id);
            await _moderatorShopRepository.Save();
        }

        public async Task<IEnumerable<ModeratorShopDTO>> GetAllAsync()
        {
            var moderatorShop = await _moderatorShopRepository.GetAll();
            return _mapper.Map<IEnumerable<ModeratorShopDTO>>(moderatorShop);
        }

        public async Task<ModeratorShopDTO> GetByIdAsync(int id)
        {
            var moderatorShop = await _moderatorShopRepository.GetByID(id);
            return _mapper.Map<ModeratorShopDTO>(moderatorShop);
        }

        public async Task UpdateAsync(ModeratorShopUpdateDTO model)
        {
            var moderatorShop = _mapper.Map<ModeratorShop>(model);
            await _moderatorShopRepository.Update(moderatorShop);
            await _moderatorShopRepository.Save();
        }

        public async Task<ServiceResponse> AddModeratorShopAsync(CreateModeratorUserDTO model)
        {
            try
            {
                if (model == null)
                {
                    return new ServiceResponse(false, "Model cannot be null", payload: null);
                }

                var appUser = await _userManager.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == model.Email);
                var shop = await _shopService.GetByIdAsync(model.ShopId);

                if (appUser != null)
                {
                    var newModeratorShop = new ModeratorShopCreateDTO
                    {
                        ShopId = shop.Id,
                        AppUserId = appUser.Id,
                    };
                    await AddAsync(newModeratorShop);

                    await UpdateUserRole(appUser, "ModeratorSeller");

                    // Sending email notification for existing user
                    string url = $"http://localhost:5173/login";
                    string emailBody = $"<h1>You have been granted access to the store {shop.FullName}. Log in for further interaction.</h1><a href='{url}'>Login now</a>";
                    await _emailService.SendEmailAsync(model.Email, "Store Registration Successful", emailBody);

                    return new ServiceResponse(true, "Success", payload: _mapper.Map<UserDTO>(appUser));
                }
                else
                {
                    var newUser = new AppUser
                    {
                        Email = model.Email,
                        UserName = model.Email,
                        EmailConfirmed = false,
                        FirstName = null,
                        LastName = null,
                        CompanyId = shop.CompanyId,
                        PhoneNumber = null,
                    };

                    var password = Utility.GenerateRandomPassword();
                    var createResult = await _userManager.CreateAsync(newUser, password);

                    if (!createResult.Succeeded)
                    {
                        throw new Exception("Failed to create user.");
                    }

                    // Instead of fetching again, use the instance already tracked
                    await UpdateUserRole(newUser, "ModeratorSeller");

                    var user = await _userManager.FindByEmailAsync(newUser.Email);
                    var newModeratorShop = new ModeratorShopCreateDTO
                    {
                        ShopId = shop.Id,
                        AppUserId = user.Id,
                    };
                    await AddAsync(newModeratorShop);

                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                    var encodedToken = Encoding.UTF8.GetBytes(token);
                    var validEmailToken = WebEncoders.Base64UrlEncode(encodedToken);

                    string confirmUrl = $"http://localhost:5173/ConfirmEmail?userId={newUser.Id}&token={validEmailToken}";
                    string confirmEmailBody = $"<h1>You have been granted access to the store {shop.FullName}.</h1><h1>Confirm your email please.</h1><hr><h2>Your password: {password}</h2><a href='{confirmUrl}'>Confirm now</a>";
                    await _emailService.SendEmailAsync(newUser.Email, "Confirm your email", confirmEmailBody);

                    return new ServiceResponse(true, "Success", payload: _mapper.Map<UserDTO>(newUser));
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse(false, ex.Message, payload: null);
            }
        }

        private async Task UpdateUserRole(AppUser user, string role)
        {
            var currentRoles = await _userManager.GetRolesAsync(user);
            if (currentRoles.Any())
            {
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
            }
            await _userManager.AddToRoleAsync(user, role);
        }


    }
}
