using Microsoft.EntityFrameworkCore;
using Domain;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TodoItem> ToDos => Set<TodoItem>();
        public DbSet<User> Users => Set<User>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>(entity =>
            {
                entity.ToTable("ToDos"); // اسم جدول

                entity.HasOne(d => d.User)           // TodoItem یک User داره
                      .WithMany(p => p.ToDos)    // User چند تا TodoItem داره
                      .HasForeignKey(d => d.UserId)  // کلید خارجی
                      .OnDelete(DeleteBehavior.Cascade) // حذف آبشاری
                      .HasConstraintName("FK_ToDos_Users_UserId");

                // UserId می‌تونه NULL باشه (برای داده‌های قدیمی)
                entity.Property(e => e.UserId)
                      .IsRequired(false);
            });

            base.OnModelCreating(modelBuilder);
        }
    
    }


}
