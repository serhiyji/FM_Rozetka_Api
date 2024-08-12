using FM_Rozetka_Api.Core.Entities;

namespace FM_Rozetka_Api.Core.DTOs.Token
{
    public class Tokens
    {
        public string Token { get; set; } = string.Empty;
        public RefreshToken refreshToken { get; set; }
    }
}
