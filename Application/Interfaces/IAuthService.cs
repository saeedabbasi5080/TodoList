using Domain.Entities;

namespace Application
{
    public interface IAuthService
    {
        Task<string> RegisterAsync1(string username, string password);
        Task<string> LoginAsync(string username, string password);
    }
}
