using New.Api.Core.Models;

namespace New.Api.Core.Interfaces
{
    public interface ILoginService
    {
        Task<UserDto> LoginUser(string login, string password);
    }
}