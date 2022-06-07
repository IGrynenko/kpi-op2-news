using News.Database.Entities;

namespace New.Api.Core.Interfaces;

public interface IAuthorsService
{
    Task<List<Author>> GetAll();
}