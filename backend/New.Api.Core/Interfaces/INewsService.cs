using New.Api.Core.Models;

namespace New.Api.Core.Interfaces
{
    public interface INewsService
    {
        Task<ArticleDto> AddArticle(ArticleModel articleModel);
        Task<List<ArticleDto>> GetAllByAuthor(int authorId);
        Task<List<ArticleDto>> GetAllByCategory(int categoryId);
        Task<List<ArticleDto>> GetAllByPeriod(DateTime startdDate, DateTime endDate);
        Task<List<ArticleDto>> GetAllByTags(int[] categoryIds);
        Task<List<ArticleDto>> GetAllNews();
    }
}