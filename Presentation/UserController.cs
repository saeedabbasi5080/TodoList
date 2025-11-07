using Application;
using Microsoft.AspNetCore.Mvc;

namespace Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService) => _userService = userService;
        //{
        //    _userService = userService;
        //}


        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> Get()
        {
            return Ok(await _userService.GetAllAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user is null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromBody] UserDto userDto)
        {
            var user = await _userService.CreateAsync(userDto);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user );
        }

        [HttpPut("id")]
        public async Task<ActionResult> Put(int id, [FromBody] UserDto userDto)
        {
            if (id != userDto.Id) return BadRequest();
            await _userService.UpdateAsync(id, userDto);
            return Ok(userDto);
        }

        [HttpDelete("id")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }

}
