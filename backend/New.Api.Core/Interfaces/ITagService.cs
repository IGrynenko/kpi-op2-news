using News.Database.Entities;

namespace New.Api.Core.Interfaces;

public interface ITagsService
{
    Task<List<Tag>> GetAll();
}