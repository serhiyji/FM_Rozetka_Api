using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using FM_Rozetka_Api.Core.Responses;
using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Interfaces;

namespace FM_Rozetka_Api.Core.Services
{
    public class LiqPayService
    {
        private readonly string _publicKey;
        private readonly string _privateKey;
        private readonly string _encryptionKey;
        private readonly ICartItemService _cartItemService;

        public LiqPayService(IConfiguration configuration, ICartItemService cartItemService)
        {
            _publicKey = configuration["LiqPay:PublicKey"];
            _privateKey = configuration["LiqPay:PrivateKey"];
            _encryptionKey = configuration["Encryption:Key"];
            _cartItemService = cartItemService;
        }

        public async Task<ServiceResponse<string, object>> CreatePaymentLink(decimal amount, string currency, string description, int[] CartItemIds)
        {
            try
            {
                var response = await _cartItemService.GetByIds(CartItemIds);

                if (!response.Success || response.Payload == null)
                {
                    return new ServiceResponse<string, object>(false, "Failed to retrieve cart items.");
                }

                var temporaryOrderId = Guid.NewGuid().ToString();
 
                var cartItems = response.Payload;

                var cartItemIds = cartItems.Select(item => item.Id.ToString()).ToArray();
                var idsString = string.Join("|", cartItemIds);
                var encryptedData = Utility.Encrypt(idsString, _encryptionKey);
                var data = new
                {
                    version = 3,
                    public_key = _publicKey,
                    action = "pay",
                    amount = amount,
                    currency = currency,
                    description = description + $" ({encryptedData})",
                    order_id = temporaryOrderId,
                    sandbox = 1,
                    server_url = "https://mayba.itstep.click/api/Payment/callback",
                    result_url = $"http://techno.itstep.click/payment-result?order_id={temporaryOrderId}"
                };

                var dataString = JsonConvert.SerializeObject(data);
                var dataBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(dataString));
                var signature = GenerateSignature(dataBase64);

                var paymentLink = $"https://www.liqpay.ua/api/3/checkout?data={dataBase64}&signature={signature}";

                //string descriptionText = data.description;
                //Console.WriteLine($"Description: {descriptionText}");

                //var regex = new System.Text.RegularExpressions.Regex(@"\(([^)]+)\)");
                //var match = regex.Match(descriptionText);
                //if (match.Success)
                //{
                //    // Видаляємо дужки
                //    string encryptedDescription = match.Groups[1].Value;
                //    Console.WriteLine($"Extracted encrypted description: {encryptedDescription}");

                //    try
                //    {
                //        string decryptedDescription = Utility.Decrypt(encryptedDescription, _encryptionKey);
                //        Console.WriteLine($"Decrypted description: {decryptedDescription}");
                        
                //    }
                //    catch (Exception ex)
                //    {
                //        Console.WriteLine($"Decryption failed: {ex.Message}");
                //    }
                //}
                //else
                //{
                //    Console.WriteLine("Failed to extract encrypted description.");
                //}





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

        public bool VerifySignature(string data, string signature)
        {
            var expectedSignature = GenerateSignature(data);
            return signature == expectedSignature;
        }
    }




}
