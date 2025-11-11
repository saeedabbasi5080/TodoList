

using Application;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthService (AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public Task<string> LoginAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<string> RegisterAsync1(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
