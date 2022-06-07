using Microsoft.AspNetCore.Mvc;
using New.Api.Core.Interfaces;
using New.Api.Core.Models;

namespace News.Api.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService _authorsService;

        public AuthorsController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<AuthorDto>>> GetAll()
        {
            var categories = await _authorsService.GetAll();

            return Ok(categories);
        }
    }
}
