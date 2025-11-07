using Microsoft.AspNetCore.Mvc;
using Application;
using System.Reflection.Metadata.Ecma335;

namespace Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _service;

        public TodoController(TodoService todoService) //=> _service = todoService;
        {
            _service = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoDto>>> Get(int userId) //=> Ok(await _service.GetAllAsync());
        {
            return Ok(await _service.GetAllAsync(userId));
        }

        [HttpGet("id")]
        public async Task<ActionResult<TodoDto?>> GetById(int id, int userId)
        {
            var item = await _service.GetByIdAsync(id, userId);
            if (item is null)
                return NotFound();

            return Ok(item);

        }

        [HttpPost]
        public async Task<ActionResult<TodoDto>> Post(int userId, [FromBody] TodoDto dto)
        {
            var item = await _service.CreateAsync(dto, userId);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("id")]
        public async Task<ActionResult> Put(int userId ,int id, [FromBody] TodoDto dto)
        {
            if (id != dto.Id) return BadRequest();
            await _service.UpdateAsync(id, dto, userId);
            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<ActionResult> Delete(int id, int userId)
        {
            await _service.DeleteAsync(id, userId);
            return NoContent();
        }

    }
}
