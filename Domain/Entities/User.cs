namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public List<TodoItem> ToDos { get; set; } = new();
    }
}
