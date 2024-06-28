using FluentValidation;
using FM_Rozetka_Api.Core.DTOs;
using FM_Rozetka_Api.Core.DTOs.Seller;
using FM_Rozetka_Api.Core.DTOs.User;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Core.Services;
using FM_Rozetka_Api.Core.Validation.Seller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace FM_Rozetka_Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerService _sellerService;
       

        public SellerController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }


        [HttpPost("seller-start")]
        public async Task<IActionResult> SellerStart([FromBody] CreateSellerApplicationDTO model)
        {
            var validator = new CreateSellerApplicationValidation();
            var validationResult = await validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var createdApplication = await _sellerService.AddApplicationAsync(model);
            return Ok(createdApplication);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllApplications()
        {
            var applications = await _sellerService.GetAllApplicationsAsync();
            return Ok(applications);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicationById(int id)
        {
            var application = await _sellerService.GetApplicationByIdAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            return Ok(application);
        }

       
        

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplication( [FromBody] UpdateSellerApplicationDTO application)
        {
            if (application == null)
            {
                return BadRequest("Application data is invalid.");
            }

            var validator = new UpdateSellerApplicationValidation();
            var validationResult = await validator.ValidateAsync(application);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var existingApplication = await _sellerService.GetApplicationByIdAsync(application.Id);
            if (existingApplication == null)
            {
                return NotFound();
            }

            await _sellerService.UpdateApplicationAsync(application);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            var application = await _sellerService.GetApplicationByIdAsync(id);
            if (application == null)
            {
                return NotFound();
            }

            await _sellerService.DeleteApplicationAsync(id);
            return NoContent();
        }
    }
}
