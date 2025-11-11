using Microsoft.EntityFrameworkCore;
using Application;
using Domain.Entities;

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

        public async Task DeleteAsynk1(int id, int userId)
        {
            var item = await GetByIdAsync1(id, userId);
            if (item != null)
            {
                _context.ToDos.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TodoItem>> GetAllAsync1(int UserId) //=> await _context.ToDos.ToListAsync();
        {
            var item = await _context.ToDos.Where(t => t.UserId == UserId).ToListAsync();
            return item;
        }

        public async Task<TodoItem?> GetByIdAsync1(int id, int UserId) //=> await _context.ToDos.FindAsync(id);
        {
            var item = await _context.ToDos.FirstOrDefaultAsync(t => t.Id == id && t.UserId == UserId);
            return item;
        }

        public async Task UpdateAsync1(TodoItem item)
        {
            // چک کن UserId حتماً مقدار داشته باشه
            if (!item.UserId.HasValue)
                throw new ArgumentException("UserId is required");

            var existing = await GetByIdAsync1(item.Id, item.UserId.Value); // .Value اضافه کن!

            //var existing = await GetByIdAsync1(item.Id, item.UserId);
            if (existing is null)
                throw new Exception("Todo not found or access denied");

            _context.ToDos.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
