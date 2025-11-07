using Microsoft.EntityFrameworkCore;
using Domain;

namespace Infrastructure
{
    public class ToDoRepository : ITodoRepository
    {
        private readonly AppDbContext _context;

        public ToDoRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task AddAsync1(TodoItem item)
        {
            _context.ToDos.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsynk1(int id)
        {
            var item = await GetByIdAsync1(id);
            if (item != null)
            {
                _context.ToDos.Remove(item);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync1() => await _context.ToDos.ToListAsync();
        //{
        //    var item = await _context.ToDos.ToListAsync();
        //    return item;
        //}

        public async Task<TodoItem?> GetByIdAsync1(int id) => await _context.ToDos.FindAsync(id);
        //{
        //    var item = await _context.ToDos.FindAsync(id);
        //    return item;
        //}

        public async Task UpdateAsync1(TodoItem item)
        {
            _context.ToDos.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
