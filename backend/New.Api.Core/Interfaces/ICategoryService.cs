using News.Database.Entities;

namespace New.Api.Core.Interfaces;

public interface ICategoriesService
{
    Task<List<Category>> GetAll();
}