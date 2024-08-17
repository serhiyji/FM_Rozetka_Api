using FM_Rozetka_Api.Core.DTOs.Products.ProductQuestion;
using FM_Rozetka_Api.Core.DTOs.Review;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FM_Rozetka_Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllReviews()
        {
            var response = await _reviewService.GetAllReviews();
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var response = await _reviewService.GetReviewById(id);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] ReviewCreateDTO model)
        {
            var response = await _reviewService.CreateReview(model);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateReview([FromBody] ReviewUpdateDTO reviewDTO)
        {
            var response = await _reviewService.UpdateReview(reviewDTO);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var response = await _reviewService.DeleteReview(id);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }
    }
}
