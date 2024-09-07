using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using FM_Rozetka_Api.Core.Responses;

namespace FM_Rozetka_Api.Core.Services
{
    public class LiqPayService
    {
        private readonly string _publicKey;
        private readonly string _privateKey;

        public LiqPayService(IConfiguration configuration)
        {
            _publicKey = configuration["LiqPay:PublicKey"];
            _privateKey = configuration["LiqPay:PrivateKey"];
        }

        public ServiceResponse<string, object> CreatePaymentLink(decimal amount, string currency, string description)
        {
            try
            {
                var temporaryOrderId = Guid.NewGuid().ToString();

                var data = new
                {
                    version = 3,
                    public_key = _publicKey,
                    action = "pay",
                    amount = amount,
                    currency = currency,
                    description = description,
                    order_id = temporaryOrderId,
                    sandbox = 1,
                    server_url = "https://your-server.com/api/payment/callback",
                    return_url= "http://localhost:5173/user/products"
                };

                var dataString = JsonConvert.SerializeObject(data);
                var dataBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(dataString));
                var signature = GenerateSignature(dataBase64);

                var paymentLink = $"https://www.liqpay.ua/api/3/checkout?data={dataBase64}&signature={signature}";

                return new ServiceResponse<string, object>(true, "Payment link created successfully", payload: paymentLink);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<string, object>(false, "Failed to create payment link: " + ex.Message);
            }
        }

        private string GenerateSignature(string data)
        {
            using (var sha1 = SHA1.Create())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(_privateKey + data + _privateKey));
                return Convert.ToBase64String(hash);
            }
        }
    }




}
