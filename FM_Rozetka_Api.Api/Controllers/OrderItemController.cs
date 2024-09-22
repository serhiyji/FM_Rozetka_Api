using FM_Rozetka_Api.Core.DTOs.OrderItem;
using FM_Rozetka_Api.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FM_Rozetka_Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] OrderItemCreateDTO model)
        {
            var response = await _orderItemService.AddAsync(model);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] OrderItemUpdateDTO model)
        {
            var response = await _orderItemService.UpdateAsync(model);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _orderItemService.DeleteAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _orderItemService.GetAllAsync();
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _orderItemService.GetByIdAsync(id);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("getAllByOrderId")]
        public async Task<IActionResult> GetAllByOrderId(int id)
        {
            var response = await _orderItemService.GetAllOrderId(id);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
