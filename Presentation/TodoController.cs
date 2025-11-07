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
        public async Task<ActionResult<List<TodoDto>>> Get() //=> Ok(await _service.GetAllAsync());
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult<TodoDto?>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item is null)
                return NotFound();

            return Ok(item);

        }

        [HttpPost]
        public async Task<ActionResult<TodoDto>> Post([FromBody] TodoDto dto)
        {
            var item = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("id")]
        public async Task<ActionResult> Put(int id, [FromBody] TodoDto dto)
        {
            if (id != dto.Id) return BadRequest();
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

    }
}
