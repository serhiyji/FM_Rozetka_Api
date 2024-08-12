
namespace FM_Rozetka_Api.Core.DTOs.Token
{
    public class TokenRequestDto
    {
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
