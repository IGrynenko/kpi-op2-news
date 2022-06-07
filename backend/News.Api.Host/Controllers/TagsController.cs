using Microsoft.AspNetCore.Mvc;
using New.Api.Core.Interfaces;
using New.Api.Core.Models;

namespace News.Api.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagsService _tagsService;

        public TagsController(ITagsService tagsService)
        {
            _tagsService = tagsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TagDto>>> GetAll()
        {
            var categories = await _tagsService.GetAll();

            return Ok(categories);
        }
    }
}
