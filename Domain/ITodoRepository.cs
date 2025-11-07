using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
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
