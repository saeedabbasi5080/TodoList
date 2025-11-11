using Domain.Entities;

namespace Application
{
    public interface ITodoRepository
    { 
        Task <List<TodoItem>> GetAllAsync1(int UserId);
        Task<TodoItem?> GetByIdAsync1(int id, int UserId);
        Task AddAsync1(TodoItem item);
        Task UpdateAsync1(TodoItem item);
        Task DeleteAsynk1 (int id, int userId);
    }
}
