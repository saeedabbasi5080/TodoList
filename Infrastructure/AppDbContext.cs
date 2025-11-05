using Microsoft.EntityFrameworkCore;
using Domain;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }

        public DbSet<TodoItem> ToDos => Set<TodoItem>();
    }
}
