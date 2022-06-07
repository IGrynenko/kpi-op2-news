using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using New.Api.Core.Interfaces;
using New.Api.Core.Models;

namespace News.Api.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly ILogger<NewsController> _logger;
        private readonly INewsService _newsService;

        public NewsController(ILogger<NewsController> logger, INewsService newsService)
        {
            _logger = logger;
            _newsService = newsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ArticleDto>>> GetAll()
        {
            var news = await _newsService.GetAllNews();

            return Ok(news);
        }

        [HttpGet("author/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ArticleDto>>> GetAllByAuthor(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid id");

            var news = await _newsService.GetAllByAuthor(id);

            if (!news.Any())
                return NotFound();

            return Ok(news);
        }

        [HttpGet("category/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ArticleDto>>> GetAllByCategory(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid id");

            var news = await _newsService.GetAllByCategory(id);

            if (!news.Any())
                return NotFound();

            return Ok(news);
        }

        [HttpPost("tags")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ArticleDto>>> GetAllByTags([FromBody] int[] tagIds)
        {
            if (tagIds.Any(i => i <= 0))
                return BadRequest("Invalid id");

            var news = await _newsService.GetAllByTags(tagIds);

            if (!news.Any())
                return NotFound();

            return Ok(news);
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ArticleDto>>> AddArticle([FromBody] ArticleModel articleModel)
        {
            var news = await _newsService.AddArticle(articleModel);

            return Ok(news);
        }

        [HttpPost("date")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ArticleDto>>> GetArticleByDate([FromBody] SearchArticleByDateModel searchModel)
        {
            var news = await _newsService.GetAllByPeriod(searchModel.StartDate, searchModel.EndDate);

            if (!news.Any())
                return NotFound();

            return Ok(news);
        }
    }
}