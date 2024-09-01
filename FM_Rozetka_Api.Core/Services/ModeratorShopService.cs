using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Shops;
using FM_Rozetka_Api.Core.DTOs.Shops.ModeratorShop;
using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Specifications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace FM_Rozetka_Api.Core.Services
{
    internal class ModeratorShopService : IModeratorShopService
    {
        private readonly IRepository<ModeratorShop> _moderatorShopRepository;
        private readonly IMapper _mapper;

        private readonly IShopService _shopService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;
        public ModeratorShopService(
                IRepository<ModeratorShop> moderatorShopRepository,
                IMapper mapper, 
                IShopService shopService,
                UserManager<AppUser> userManager, 
                IEmailService emailService
            )
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
            var moderatorshop = await GetByIdAsync(id);
            var user = await _userManager.FindByIdAsync(moderatorshop.AppUserId);
            await _moderatorShopRepository.Delete(id);
            await _moderatorShopRepository.Save();
            UpdateUserRole(user, "User");
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

                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
                    var encodedToken = Encoding.UTF8.GetBytes(token);
                    var validEmailToken = WebEncoders.Base64UrlEncode(encodedToken);

                    string confirmUrl = $"http://localhost:5173/ConfirmRoleModerator?userId={appUser.Id}&token={validEmailToken}&shopId={shop.Id}";
                    string emailBody = $"<h1>You have been granted access to the store {shop.FullName}.Confirm for next interaction.</h1><a href='{confirmUrl}'>Confirm now</a>";

                    await _emailService.SendEmailAsync(model.Email, "Moderator access granted", emailBody);

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
                        PhoneNumber = null,
                    };

                    var password = Utility.GenerateRandomPassword();
                    var createResult = await _userManager.CreateAsync(newUser, password);

                    if (!createResult.Succeeded)
                    {
                        throw new Exception("Failed to create user.");
                    }

                    var user = await _userManager.FindByEmailAsync(newUser.Email);
                   
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                    var encodedToken = Encoding.UTF8.GetBytes(token);
                    var validEmailToken = WebEncoders.Base64UrlEncode(encodedToken);

                    string confirmUrl = $"http://localhost:5173/ConfirmRoleModerator?userId={user.Id}&token={validEmailToken}&shopId={shop.Id}";
                    string confirmEmailBody = $"<h1>You have been granted access to the store {shop.FullName}.</h1><h1>Confirm for next interaction.</h1><hr><h2>Your password: {password}</h2><a href='{confirmUrl}'>Confirm now</a>";
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

        public async Task<ServiceResponse<IEnumerable<UserModeratorShopDTO>, object>> GetUsersByShopId(int shopid)
        {
            try
            {
                if (shopid != 0) 
                {
                    var shopModerators = (await _moderatorShopRepository.GetListBySpec(new ModeratorShopSpecification.GetUserModeratorShop(shopid))).ToList();
                    var users = shopModerators.Select(m => m.AppUser).ToList();
                    var map = _mapper.Map<List<UserModeratorShopDTO>>(users);
                    for (int i = 0; i < map.Count(); i++)
                    {
                        map[i].IdModeratorShop = shopModerators[i].Id;
                    }
                    return new ServiceResponse<IEnumerable<UserModeratorShopDTO>, object>(true, "Success", payload: map);
                }
                return new ServiceResponse<IEnumerable<UserModeratorShopDTO>, object>(false, "Failed: shopid is zero or null", payload: null);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<UserModeratorShopDTO>, object>(false, $"Failed: {ex.Message}", payload: null);
            }
        }

        public async Task<ServiceResponse> ConfirmModeratorRoleAsync(ConfirmModeratorRoleDTO model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.AppUserId);

                if (user == null)
                    return new ServiceResponse(false, "unknown user");

                if (user.EmailConfirmed == false)
                {
                    var decodedToken = WebEncoders.Base64UrlDecode(model.token);
                    string normalToken = Encoding.UTF8.GetString(decodedToken);
                    var result = await _userManager.ConfirmEmailAsync(user, normalToken);

                    if (!result.Succeeded)
                        return new ServiceResponse(false, "User`s email not confirmed", result.Errors.Select(e => e.Description));
                }

                var newModeratorShop = new ModeratorShopCreateDTO
                {
                    ShopId = model.ShopId,
                    AppUserId = model.AppUserId,
                };

                await AddAsync(newModeratorShop);

                await UpdateUserRole(user, "ModeratorSeller");

                return new ServiceResponse(true, "Successful confirmation of actions");
            }
            catch (Exception ex)
            {
                return new ServiceResponse(false, $"An error occurred: {ex.Message}");
            }



        }


    }
}
