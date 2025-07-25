﻿using FM_Rozetka_Api.Core.DTOs.Orders.Order;
using FM_Rozetka_Api.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FM_Rozetka_Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] OrderCreateDTO model)
        {
            var response = await _orderService.AddAsync(model);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] OrderUpdateDTO model)
        {
            var response = await _orderService.UpdateAsync(model);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _orderService.DeleteAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _orderService.GetAllAsync();
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _orderService.GetByIdAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("orderId/{id}")]
        public async Task<IActionResult> GetByOrderId(string id)
        {
            var response = await _orderService.GetByOrderIdAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("GetAllStatistics")]
        public async Task<IActionResult> GetAllStatistics(int shopId)
        {

            var salesStatistics = await _orderService.GetAllStatistics(shopId);

            if (salesStatistics == null || !salesStatistics.Any())
            {
                return NotFound(new { message = "No sales data found for this shop." });
            }

            return Ok(salesStatistics);
        }

        [HttpGet("GetAllStatistic")]
        public async Task<IActionResult> GetAllStatistic()
        {

            var salesStatistics = await _orderService.GetAllStatistic();

            if (salesStatistics == null || !salesStatistics.Any())
            {
                return NotFound(new { message = "No sales data found for this shop." });
            }

            return Ok(salesStatistics);
        }

        [HttpGet("GetAllStatisticByUserId")]
        public async Task<IActionResult> GetAllStatisticByUserId([FromQuery] string appUserId)
        {
            var salesStatistics = await _orderService.GetAllStatisticByAppUserId(appUserId);

            if (salesStatistics == null || !salesStatistics.Any())
            {
                return NotFound(new { message = "No sales data found for this shop." });
            }

            return Ok(salesStatistics);
        }



    }
}
