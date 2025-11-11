using Domain.Entities;

namespace Application
{ 
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task <User?> GetById(int id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}
