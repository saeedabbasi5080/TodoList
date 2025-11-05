using Domain;

namespace Application
{
    public class TodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TodoDto>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync1();
            return items.Select(i => new TodoDto
            {
                Id = i.Id,
                Title = i.Title,
                IsCompleted = i.IsCompleted,
            }).ToList();
        }

        public async Task<TodoDto?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync1(id);
            return item == null ? null : new TodoDto
            {
                Id = item.Id,
                Title = item.Title,
                IsCompleted = item.IsCompleted,
            };
        }

        public async Task<TodoDto> CreateAsync(TodoDto dto)
        {
            var item = new TodoItem { Title = dto.Title };
            await _repository.AddAsync1(item);
            dto.Id = item.Id;
            return dto;
        }

        public async Task UpdateAsync(int id, TodoDto dto) 
        {
            var item = await _repository.GetByIdAsync1(id) ?? throw new Exception("Item not found");
            item.Title = dto.Title;
            item.IsCompleted = dto.IsCompleted;
            await _repository.UpdateAsync1(item);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsynk1(id);
        }
    }
}
