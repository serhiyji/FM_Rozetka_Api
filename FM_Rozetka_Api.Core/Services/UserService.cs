using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.DTOs.Products.Product;
using FM_Rozetka_Api.Core.Specifications;

namespace FM_Rozetka_Api.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        private readonly IShopService _shopService;
        private readonly IModeratorShopService _moderatorshopService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        public UserService(
                IEmailService emailService,
                SignInManager<AppUser> signInManager,
                UserManager<AppUser> userManager,
                IMapper _mapper,
                IConfiguration configuration,
                IShopService shopService,
                IModeratorShopService moderatorShopService
            )
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._mapper = _mapper;
            this._configuration = configuration;
            this._emailService = emailService;
            _shopService = shopService;
            _moderatorshopService = moderatorShopService;
        }
        public async Task<ServiceResponse> CreateUserAsync(CreateUserDTO model)
        {
            AppUser NewUser = _mapper.Map<CreateUserDTO, AppUser>(model);
            NewUser.UserName = model.Email;
            IdentityResult result = await _userManager.CreateAsync(NewUser, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(NewUser, model.Role);
                //await SendConfirmationEmailAsync(NewUser);
                return new ServiceResponse(true, "User has been added");
            }
            return new ServiceResponse(false, "Something went wrong", errors: result.Errors.Select(e => e.Description));
        }
        public async Task<ServiceResponse> DeleteUserAsync(DeleteUserDTO model)
        {
            AppUser userdelete = await _userManager.FindByIdAsync(model.Id);
            if (userdelete == null)
            {
                return new ServiceResponse(false, "User a was found");
            }

            var role = await _userManager.GetRolesAsync(userdelete);

            if (role.Contains("Seller"))
            {
                var shop = await _shopService.GetByUserIdAsync(userdelete.Id);
                var moderatorshop = await _moderatorshopService.GetUsersByShopId(shop.Id);

                foreach (var item in moderatorshop.Payload)
                {
                    await ChangeUserRoleAsync(item.AppUserId, "User");
                }

            }

            IdentityResult result = await _userManager.DeleteAsync(userdelete);
            if (result.Succeeded)
            {
                return new ServiceResponse(true);
            }
            return new ServiceResponse(false, "something went wrong", errors: result.Errors.Select(e => e.Description));
        }
        public async Task<ServiceResponse> EditUserAsync(EditUserDTO model)
        {
            AppUser? user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                return new ServiceResponse(false, "User not found.", errors: new List<string>() { "User not found." });
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            IdentityResult result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ServiceResponse(true, "User successfully updated.");
            }
            return new ServiceResponse(false, "Something went wrong", errors: result.Errors.Select(e => e.Description));
        }

        public async Task<ServiceResponse> ChangePasswordAsync(UpdatePasswordDto model)
        {
            AppUser user = _userManager.FindByIdAsync(model.Id).Result;
            if (user == null) return new ServiceResponse(false, "User or password incorrect.", errors: new List<string>() { "User or password incorrect." });

            IdentityResult result = _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword).Result;
            if (result.Succeeded)
            {
                await _signInManager.SignOutAsync();
                return new ServiceResponse(true, "Password successfully updated");
            }
            return new ServiceResponse(false, "Error.", errors: result.Errors.ToList().Select(i => i.Description));
        }

        public async Task<ServiceResponse> ChangeMainInfoUserAsync(EditUserDTO newinfo)
        {
            AppUser user = await _userManager.FindByIdAsync(newinfo.Id);

            if (user != null)
            {
                user.FirstName = newinfo.FirstName;
                user.LastName = newinfo.LastName;

                IdentityResult result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return new ServiceResponse(true, "Information has been changed");
                }
                else
                {
                    return new ServiceResponse(false, "Something went wrong", errors: result.Errors.Select(e => e.Description));
                }
            }
            return new ServiceResponse(false, "Not found user");
        }
        public async Task<ServiceResponse> GetUserByIdAsync(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                return new ServiceResponse(false, "user not found");
            }
            UpdateUserDTO mappedUser = _mapper.Map<AppUser, UpdateUserDTO>(user);
            return new ServiceResponse(true, "User successfully loaded", payload: mappedUser);
        }
        public async Task<ServiceResponse> GetAll()
        {
            List<AppUser> users = await _userManager.Users.ToListAsync();
            List<UserDTO> mappedUsers = users.Select(u => _mapper.Map<AppUser, UserDTO>(u)).ToList();

            return new ServiceResponse(true, "All users loaded.", payload: mappedUsers);
        }

        #region Confirm email and send token for confirm email
        public async Task SendConfirmationEmailAsync(AppUser user)
        {
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            byte[] encodedToken = Encoding.UTF8.GetBytes(token);
            string validEmailToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"{_configuration["HostSettings:URL"]}/confirmemail?userid={user.Id}&token={validEmailToken}";

            string emailBody = $"<h1>Confirm your email</h1> <a href='{url}'>Confirm now!</a>";
            await _emailService.SendEmailAsync(user.Email, "Email confirmation.", emailBody);
        }

        public async Task<ServiceResponse> ConfirmEmailAsync(string userId, string token)
        {
            AppUser? user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ServiceResponse(false, "User not found");
            }

            byte[] decodedToken = WebEncoders.Base64UrlDecode(token);
            string narmalToken = Encoding.UTF8.GetString(decodedToken);

            IdentityResult result = await _userManager.ConfirmEmailAsync(user, narmalToken);
            if (result.Succeeded)
            {
                return new ServiceResponse(true, "Email successfully confirmed.");
            }
            return new ServiceResponse(false, "Email not confirmed", errors: result.Errors.Select(e => e.Description));
        }
        #endregion

        #region Password recovery and send token for password recovery
        public async Task<ServiceResponse> ForgotPasswordAsync(string email)
        {
            AppUser? user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new ServiceResponse(false, "User not found.");
            }

            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            byte[] encodedToken = Encoding.UTF8.GetBytes(token);
            string validEmailToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"{_configuration["HostSettings:URL"]}/Dashboard/ResetPassword?email={email}&token={validEmailToken}";

            string emailBody = $"<h1>Follow the instruction for reset password.</h1><a href='{url}'>Reset now!</a>";
            await _emailService.SendEmailAsync(email, "Reset password for TopNews.", emailBody);

            return new ServiceResponse(true, "Email successfull send.");
        }

        public async Task<ServiceResponse> ResetPasswordAsync(PasswordRecoveryDto model)
        {
            AppUser? user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new ServiceResponse(false, "User not found.");
            }

            byte[] decodedToken = WebEncoders.Base64UrlDecode(model.Token);
            string narmalToken = Encoding.UTF8.GetString(decodedToken);
            IdentityResult res = await _userManager.ResetPasswordAsync(user, narmalToken, model.Password);
            if (res.Succeeded)
            {
                return new ServiceResponse(true, "Password changed successfully");
            }
            return new ServiceResponse(false, "Something went wrong", errors: res.Errors.Select(e => e.Description));
        }
        #endregion

        #region User manager
        public ServiceResponse<List<UserDTO>, object> GetAllAsync()
        {
            List<UserDTO> users = _mapper.Map<List<AppUser>, List<UserDTO>>(_userManager.Users.ToList());
            return new ServiceResponse<List<UserDTO>, object>(true, "", payload: users);
        }

        public async Task<ServiceResponse> ToggleBlockUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ServiceResponse(false, "User not found.");
            }

            user.LockoutEnd = user.LockoutEnd.HasValue && user.LockoutEnd > DateTimeOffset.Now
                ? (DateTimeOffset?)null
                : DateTimeOffset.UtcNow.AddYears(100);
            user.LockoutEnabled = user.LockoutEnd.HasValue;


            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return new ServiceResponse(true, user.LockoutEnd == null ? "User successfully unblocked." : "User successfully blocked.");
            }

            return new ServiceResponse(false, "Failed to toggle block status.", errors: result.Errors.Select(e => e.Description));
        }

        #endregion

        public async Task<ServiceResponse> ChangeUserRoleAsync(string userId, string newRole)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return new ServiceResponse(false, "User not found.");
                }

                var currentRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
                var result = await _userManager.AddToRoleAsync(user, newRole);

                if (result.Succeeded)
                {
                    string emailBody = $"<h1>Ваша роль була змінена на: {newRole}.</h1><p>Якщо у вас є питання, будь ласка, дайте відповідь на цей лист.</p>";
                    await _emailService.SendEmailAsync(user.Email, "Зміна ролі користувача на Rozetka", emailBody);

                    return new ServiceResponse(true, "User role updated successfully.");
                }
                return new ServiceResponse(false, "Failed to update user role.", errors: result.Errors.Select(e => e.Description));
            }
            catch (Exception ex)
            {
                return new ServiceResponse(false, "Error: " + ex.Message);
            }
        }

        public async Task<ServiceResponse<int, object>> GetTotalUserCountAsync()
        {
            try
            {
                int userCount = await _userManager.Users.CountAsync();
                return new ServiceResponse<int, object>(true, "Total user count retrieved successfully.", payload: userCount);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<int, object>(false, $"An error occurred while retrieving user count. {ex.Message}");
            }
        }

        public async Task<PaginationResponse<List<UserDTO>, object>> GetPagedUsersAsync(
             int page = 1,
             int pageSize = 10,
             string searchTerm = null)
        {
            try
            {
                var query = _userManager.Users.AsQueryable();

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    searchTerm = searchTerm.ToLower();

                    query = query.Where(u =>
                        EF.Functions.Like(u.FirstName.ToLower(), $"%{searchTerm}%") ||
                        EF.Functions.Like(u.LastName.ToLower(), $"%{searchTerm}%") ||
                        EF.Functions.Like(u.Email.ToLower(), $"%{searchTerm}%"));
                }

                int totalUsers = await query.CountAsync();

                var users = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var userDTOs = new List<UserDTO>();

                foreach (var user in users)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    var role = roles.FirstOrDefault() ?? "Unknown";

                    var userDTO = _mapper.Map<UserDTO>(user);
                    userDTO.Role = role;

                    userDTOs.Add(userDTO);
                }

                return new PaginationResponse<List<UserDTO>, object>(
                    true,
                    "Users received successfully.",
                    payload: userDTOs,
                    pageNumber: page,
                    pageSize: pageSize,
                    totalCount: totalUsers
                );
            }
            catch (Exception ex)
            {
                return new PaginationResponse<List<UserDTO>, object>(false, "Error: " + ex.Message);
            }
        }





    }
}
