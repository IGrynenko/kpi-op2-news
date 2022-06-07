using AutoMapper;
using New.Api.Core.Models;
using News.Database.Entities;

namespace New.Api.Core.Mapper
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDto>();

            CreateMap<Author, AuthorDto>();

            CreateMap<Category, CategoryDto>();

            CreateMap<Tag, TagDto>();

            CreateMap<Author, UserDto>();
        }
    }
}
