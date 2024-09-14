using FM_Rozetka_Api.Core.DTOs.Orders.Payment;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace FM_Rozetka_Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly LiqPayService _liqPayService;

        public PaymentController(IPaymentService paymentService, LiqPayService liqPayService)
        {
            _paymentService = paymentService;
            _liqPayService = liqPayService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] PaymentCreateDTO model)
        {
            var response = await _paymentService.AddAsync(model);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] PaymentUpdateDTO model)
        {
            var response = await _paymentService.UpdateAsync(model);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _paymentService.DeleteAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _paymentService.GetAllAsync();
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _paymentService.GetByIdAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("create-payment-link")]
        public IActionResult CreatePaymentLink([FromBody] PaymentLinkCreateDTO model)
        {
            var response = _liqPayService.CreatePaymentLink(model.Amount, model.Currency, model.Description);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("callback")]
        public IActionResult PaymentCallback([FromForm] string data, [FromForm] string signature)
        {
            if (!_liqPayService.VerifySignature(data, signature))
            {
                Console.WriteLine("Invalid signature");
                return BadRequest("Invalid signature");
            }

            var decodedData = Encoding.UTF8.GetString(Convert.FromBase64String(data));
            dynamic paymentInfo = Newtonsoft.Json.Linq.JObject.Parse(decodedData);

            if (paymentInfo.status == "success")
            {
                Console.WriteLine($"Payment successful. Order ID: {paymentInfo.order_id}");
            }
            else
            {
                Console.WriteLine($"Payment failed. Order ID: {paymentInfo.order_id}");
            }

            return Ok(); 
        }
    }
}
