using AutoMapper;
using Microsoft.EntityFrameworkCore;
using New.Api.Core.Interfaces;
using New.Api.Core.Models;
using News.Database;
using News.Database.Entities;
using System.Linq.Expressions;

namespace New.Api.Core.Services
{
    public class NewsService : INewsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NewsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ArticleDto> AddArticle(ArticleModel articleModel)
        {
            var modelTags = articleModel.Tags.ToList();

            var tags = await _unitOfWork.Get<Tag>()
                .Where(e => modelTags.Contains(e.Id))
                .ToListAsync();

            var article = new Article
            {
                Title = articleModel.Title,
                Text = articleModel.Text,
                AuthorId = articleModel.AuthorId,
                CategoryId = articleModel.CategoryId
            };

            _unitOfWork.Add(article);
            article.Tags = tags;

            await _unitOfWork.CommitAsync();

            return _mapper.Map<ArticleDto>(article);
        }

        public async Task<List<ArticleDto>> GetAllNews()
        {
            var news = await _unitOfWork.Get<Article>()
                .Include(e => e.Author)
                .Include(e => e.Category)
                .Include(e => e.Tags)
                .ToListAsync();

            return news.Select(e => _mapper.Map<ArticleDto>(e)).ToList();
        }

        public async Task<List<ArticleDto>> GetAllByAuthor(int authorId)
        {
            return await GetNewsBy(e => e.AuthorId == authorId);
        }

        public async Task<List<ArticleDto>> GetAllByCategory(int categoryId)
        {
            return await GetNewsBy(e => e.CategoryId == categoryId);
        }

        public async Task<List<ArticleDto>> GetAllByPeriod(DateTime startdDate, DateTime endDate)
        {
            return await GetNewsBy(e => e.CreatedAt >= startdDate && e.CreatedAt <= endDate);
        }

        public async Task<List<ArticleDto>> GetAllByTags(int[] categoryIds)
        {
            return await GetNewsBy(e => e.Tags.Any(t => categoryIds.Contains(t.Id)));
        }

        private async Task<List<ArticleDto>> GetNewsBy(Expression<Func<Article, bool>> predicate)
        {
            var news = await _unitOfWork.Get<Article>()
                .Include(e => e.Author)
                .Include(e => e.Category)
                .Include(e => e.Tags)
                .Where(predicate)
                .ToListAsync();

            return news.Select(e => _mapper.Map<ArticleDto>(e)).ToList();
        }
    }
}
