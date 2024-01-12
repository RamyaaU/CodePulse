using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDBContext _dBContext;

        public CategoriesController(ApplicationDBContext dBContext)
        {
                _dBContext = dBContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDTO requestDTO)
        {
            //map DTO to domain models
            var category = new Category
            {
                Name = requestDTO.Name,
                UrlHandle = requestDTO.UrlHandle,
            };

            await _dBContext.Categories.AddAsync(category);
            await _dBContext.SaveChangesAsync();

            // map again domain model to dto 
            var response = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);
        }
    }
}
