using Application.DTOs.ToDoDTOs;

namespace Application.DTOs.UserDTOs
{
    public class CreateUserDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        //public List<CreateToDoDto> TodoDtos { get; set; } = new();
    }
}
