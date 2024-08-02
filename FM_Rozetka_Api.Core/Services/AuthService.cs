using AutoMapper;
using FM_Rozetka_Api.Core.DTOs.Token;
using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Responses;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FM_Rozetka_Api.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IJwtService _jwtService;

        public AuthService(
                UserManager<AppUser> userManager,
                SignInManager<AppUser> signInManager,
                RoleManager<IdentityRole> roleManager,
                IEmailService emailService,
                IMapper mapper,
                IConfiguration configuration,
                IJwtService jwtService,
                IUserService userService
            )
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._emailService = emailService;
            this._mapper = mapper;
            this._configuration = configuration;
            this._jwtService = jwtService;
            this._userService = userService;
        }

        #region SignIn, SignOut
        public async Task<ServiceResponse> LoginUserAsync(UserLoginDTO model)
        {
            AppUser? user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new ServiceResponse(false, "User or password incorect.");
            }
            SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                Tokens? tokens = await _jwtService.GenerateJwtTokensAsync(user);
                await _signInManager.SignInAsync(user, model.RememberMe);
                return new ServiceResponse(true, "User successfully loged in.", payload:true, accessToken: tokens.Token, refreshToken: tokens.refreshToken.Token);
            }
            if (result.IsNotAllowed)
            {
                return new ServiceResponse(false, "Confirm your email please");
            }
            if (result.IsLockedOut)
            {
                return new ServiceResponse(false, "User is locked. Connect with your site admistrator.");
            }
            return new ServiceResponse(false, "User or password incorect");
        }
        public async Task<ServiceResponse> LoginUserByPhoneAsync(UserLoginPhoneDTO model)
        {
            AppUser? user = await _userManager.Users.SingleOrDefaultAsync(u => u.PhoneNumber == model.Phone);

            if (user == null)
            {
                return new ServiceResponse(false, "User or password incorect.");
            }
            SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                Tokens? tokens = await _jwtService.GenerateJwtTokensAsync(user);
                await _signInManager.SignInAsync(user, model.RememberMe);
                return new ServiceResponse(true, "User successfully loged in.", accessToken: tokens.Token, refreshToken: tokens.refreshToken.Token);
            }
            if (result.IsNotAllowed)
            {
                return new ServiceResponse(false, "Confirm your email please");
            }
            if (result.IsLockedOut)
            {
                return new ServiceResponse(false, "User is locked. Connect with your site admistrator.");
            }
            return new ServiceResponse(false, "User or password incorect");
        }
        public async Task<ServiceResponse> SignOutAsync()
        {
            await _signInManager.SignOutAsync();
            return new ServiceResponse(true);
        }
        #endregion

        public async Task<ServiceResponse> SingUpByEmailAsync(UserSignUpEmailDTO model)
        {
            if (model != null)
            {
                AppUser mappedUser = _mapper.Map<UserSignUpEmailDTO, AppUser>(model);
                var result = await _userManager.CreateAsync(mappedUser, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(mappedUser, "User");
                    //  Email sender
                    await _emailService.SendEmailAsync(model.Email, "Welcome", "Welcome to our site");
                    await SendConfirmationEmailAsync(mappedUser);
                }
                else
                {
                    return new ServiceResponse(false, "credentials are null");
                }
            }
            return new ServiceResponse
            {
                Success = false,
                Message = "Something went wrong during adding user :( ."
            };
        }

        public async Task DeleteAllRefreshTokenByUserIdAsync(string userId)
        {
            IEnumerable<RefreshToken> refreshTokens = await _jwtService.GetByUserIdAsync(userId);
            foreach (RefreshToken refreshToken in refreshTokens)
            {
                await _jwtService.Delete(refreshToken);
            }
        }

        public async Task<ServiceResponse> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return new ServiceResponse(false, "unknown user");
           
            var decodedToken = WebEncoders.Base64UrlDecode(token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);
            var result = await _userManager.ConfirmEmailAsync(user, normalToken);

            if (result.Succeeded)
                return new ServiceResponse(false, "User`s email confirmed succesfully");

            return new ServiceResponse(false, "User`s email not confirmed", result.Errors.Select(e => e.Description));
        }

        public async Task SendConfirmationEmailAsync(AppUser user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validEmailToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"http://localhost:5173/ConfirmEmail?userId={user.Id}&token={validEmailToken}";
            //string url = $"{_config["HostSetting:URL"]}/Dashboard/ConfirmEmail?userId={user.Id}&token={validEmailToken}";
            string emailBody = $"" +
                $"<h1>Confirm your email please.</h1><a href='{url}'>Confirm now</a>";
            await _emailService.SendEmailAsync(user.Email, "Rozetka Email confirmation", emailBody);
        }

        public async Task<ServiceResponse> LoginWithGoogleAsync(string tokenId)
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(tokenId, new GoogleJsonWebSignature.ValidationSettings());
            AppUser? user = await _userManager.FindByEmailAsync(payload.Email);
            if (user == null)
            {
                return new ServiceResponse(false, "User incorect.");
            }
             
            var token = await _jwtService.GenerateJwtTokensAsync(user);

            if (token != null)
            {
                Tokens? tokens = await _jwtService.GenerateJwtTokensAsync(user);
                return new ServiceResponse(true, "User successfully loged in.", accessToken: tokens.Token, payload: true, refreshToken: tokens.refreshToken.Token);
            }
           
            return new ServiceResponse(false, "User or password incorect");
        }

        public async Task<ServiceResponse> RegisterWithGoogleAsync(string tokenId)
        {
            try
            {
                var payload = await GoogleJsonWebSignature.ValidateAsync(tokenId, new GoogleJsonWebSignature.ValidationSettings());
                var user = await _userManager.FindByEmailAsync(payload.Email);

                if (user == null)
                {
                    // Створюємо нового користувача на основі інформації з Google
                    user = new AppUser
                    {
                        Email = payload.Email,
                        UserName = payload.Email,
                        EmailConfirmed = true,
                        FirstName = payload.GivenName,
                        LastName = payload.FamilyName
                    };

                    var result = await _userManager.CreateAsync(user);
                    if (!result.Succeeded)
                    {
                        return new ServiceResponse(false, "Failed to create user with Google account.");
                    }

                    await _userManager.AddToRoleAsync(user, "User");
                }

                // Генеруємо JWT токени
                var tokens = await _jwtService.GenerateJwtTokensAsync(user);
                return new ServiceResponse(true, "User successfully registered and authenticated with Google.", accessToken: tokens.Token, refreshToken: tokens.refreshToken.Token);
            }
            catch (InvalidJwtException ex)
            {
                return new ServiceResponse(false, "Invalid Google token.", ex.Message);
            }
        }

        public async Task<ServiceResponse> Regitration(RegistrationUserDTO regitrationUserDTO)
        {
            try
            {

                var user = await _userManager.FindByEmailAsync(regitrationUserDTO.Email);

                if (user == null)
                {
                    CreateUserDTO NewUser = _mapper.Map<RegistrationUserDTO, CreateUserDTO>(regitrationUserDTO);
                    // Створюємо нового користувача
                    NewUser.Role = "User";
                   
                    var result = await _userService.CreateUserAsync(NewUser);

                    var UserSenEmail = await _userManager.FindByEmailAsync(NewUser.Email);
                    await this.SendConfirmationEmailAsync(UserSenEmail);
                    if (!result.Success)
                    {
                        return new ServiceResponse(false, result.Message);
                    }
                }

                return new ServiceResponse(true, "User successfully registered.");
            }
            catch (InvalidJwtException ex)
            {
                return new ServiceResponse(false, "Invalid registered.", ex.Message);
            }
        }
    }
}
