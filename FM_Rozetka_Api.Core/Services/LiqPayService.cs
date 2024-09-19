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
using FM_Rozetka_Api.Core.DTOs.Orders.Payment;
using System.Web;

namespace FM_Rozetka_Api.Core.Services
{
    public class LiqPayService
    {
        private readonly string _publicKey;
        private readonly string _privateKey;
        private readonly string _encryptionKey;
        private readonly ICartItemService _cartItemService;
        private readonly INovaPoshtaService _novaPoshtaService;


        public LiqPayService(IConfiguration configuration, ICartItemService cartItemService, INovaPoshtaService novaPoshtaService)
        {
            _publicKey = configuration["LiqPay:PublicKey"];
            _privateKey = configuration["LiqPay:PrivateKey"];
            _encryptionKey = configuration["Encryption:Key"];
            _cartItemService = cartItemService;
            _novaPoshtaService = novaPoshtaService;
        }

        public async Task<ServiceResponse<string, object>> CreatePaymentLink(PaymentLinkCreateDTO model)
        {
            try
            {
                var response = await _cartItemService.GetByIds(model.CartItemIds);

                if (!response.Success || response.Payload == null)
                {
                    return new ServiceResponse<string, object>(false, "Failed to retrieve cart items.");
                }

                var temporaryOrderId = Guid.NewGuid().ToString();

                var cartItems = response.Payload;
                var json_alldata = JsonConvert.SerializeObject(model.AllData);

                var cartItemIds = cartItems.Select(item => item.Id.ToString()).ToArray();
                var idsString = string.Join("|", cartItemIds);
               

                // Використовувати HttpUtility.UrlEncode для кодування URL
                string encryptedCart = HttpUtility.UrlEncode(idsString);
                string encryptedCustomer = HttpUtility.UrlEncode(json_alldata);

                var data = new
                {
                    version = 3,
                    public_key = _publicKey,
                    action = "pay",
                    amount = model.Amount,
                    currency = model.Currency,
                    description = model.Description,
                    order_id = temporaryOrderId,
                    sandbox = 1,
                    server_url = $"https://mayba.itstep.click/api/Payment/callback?encrypted_cart={encryptedCart}&encrypted_customer={encryptedCustomer}",
                    result_url = $"http://techno.itstep.click/payment-result?order_id={temporaryOrderId}"
                };

                var dataString = JsonConvert.SerializeObject(data);
                var dataBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(dataString));
                var signature = GenerateSignature(dataBase64);

                var paymentLink = $"https://www.liqpay.ua/api/3/checkout?data={dataBase64}&signature={signature}";

                var area = await _novaPoshtaService.GetByIdArea(3);
                var settlement = await _novaPoshtaService.GetByIdSettlements(169);
                var warehouse = await _novaPoshtaService.GetByIdWarehouses(1251);


                Console.WriteLine(data.server_url);
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
