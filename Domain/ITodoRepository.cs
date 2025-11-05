using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface ITodoRepository
    { 
        Task <IEnumerable<TodoItem>> GetAllAsync1();
        Task<TodoItem?> GetByIdAsync1(int id);
        Task AddAsync1(TodoItem item);
        Task UpdateAsync1(TodoItem item);
        Task DeleteAsynk1 (int id);
    }
}
