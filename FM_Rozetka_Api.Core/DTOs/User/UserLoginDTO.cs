﻿
namespace FM_Rozetka_Api.Core.DTOs.User
{
    public class UserLoginDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; } = false;
    }
}
