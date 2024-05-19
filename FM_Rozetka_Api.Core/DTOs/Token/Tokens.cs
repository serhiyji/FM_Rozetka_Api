using FM_Rozetka_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.Token
{
    public class Tokens
    {
        public string Token { get; set; } = string.Empty;
        public RefreshToken refreshToken { get; set; }
    }
}
