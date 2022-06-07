using Microsoft.AspNetCore.Mvc;
using New.Api.Core.Interfaces;
using New.Api.Core.Models;

namespace News.Api.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryDto>>> GetAll()
        {
            var categories = await _categoriesService.GetAll();

            return Ok(categories);
        }
    }
}
