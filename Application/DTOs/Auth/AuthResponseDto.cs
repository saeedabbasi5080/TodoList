

namespace Application.DTOs.Auth
{
    public class AuthResponseDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
