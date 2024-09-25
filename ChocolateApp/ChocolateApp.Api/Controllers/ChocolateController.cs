using ChocolateApp.Service.Abstract;
using ChocolateApp.Shared.Dtos;
using ChocolateApp.Shared.Helpers.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChocolateApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChocolateController : ControllerBase
    {
        private readonly IChocolateService _chocolateService;
        private readonly IImageHelper _imageHelper;

        public ChocolateController(IChocolateService chocolateService, IImageHelper imageHelper)
        {
            _chocolateService = chocolateService;
            _imageHelper = imageHelper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddChocolateDto addChocolateDto)
        {
            var response = await _chocolateService.AddAsync(addChocolateDto);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        // api/chocolate
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _chocolateService.GetAllAsync();
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        // api/chocolate/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _chocolateService.GetByIdAsync(id);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(EditChocolateDto editChocolateDto)
        {
            var response = await _chocolateService.UpdateAsync(editChocolateDto);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _chocolateService.DeleteAsync(id);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        // api/chocolate/bycategory/5
        [HttpGet("bycategory/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            var response = await _chocolateService.GetChocolatesByCategoryIdAsync(categoryId);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        // api/chocolate/active/false
        [HttpGet("active/{isActive}")]
        public async Task<IActionResult> GetActiveChocolates(bool isActive)
        {
            var response = await _chocolateService.GetActiveChocolatesAsync(isActive);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("addimage")]
        public async Task<IActionResult> ImageUpload(IFormFile file)
        {
            var response = await _imageHelper.Upload(file);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
