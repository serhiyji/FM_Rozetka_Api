using FM_Rozetka_Api.Core.DTOs.Products.ProductQuestion;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FM_Rozetka_Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductQuestionController : ControllerBase
    {
        private readonly IProductQuestionService _productQuestionService;

        public ProductQuestionController(IProductQuestionService productQuestionService)
        {
            _productQuestionService = productQuestionService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] ProductQuestionCreateDTO model)
        {
            var response = await _productQuestionService.AddAsync(model);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] ProductQuestionUpdateDTO model)
        {
            var response = await _productQuestionService.UpdateAsync(model);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _productQuestionService.DeleteAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productQuestionService.GetAllAsync();
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _productQuestionService.GetByIdAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("getbyproductid")]
        public async Task<IActionResult> GetAllByProducId(int productid)
        {
            var response = await _productQuestionService.GetAllByProductIdAsync(productid);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("getallActiveQuestion")]
        public async Task<IActionResult> GetAllActiveQuestion()
        {
            var response = await _productQuestionService.GetActiveQuestions();
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }


        [HttpGet("getallActiveQuestionByShopId/{shopId}/")]
        public async Task<IActionResult> GetQuestionsByShopId(int shopId)
        {
            var response = await _productQuestionService.GetActiveQuestions(shopId);
            if (response.Success)
            {
                return Ok(response.Payload);
            }
            else
            {
                return BadRequest(new { message = response.Message });
            }
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetQuestionCount()
        {
            var result = await _productQuestionService.GetQuestionCountAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }

}
