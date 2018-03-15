using ListingTodos.Models;
using Microsoft.EntityFrameworkCore;

namespace ListingTodos.Entities
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DbSet<User> Users { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                 .HasMany(x => x.Todos)
                 .WithOne(x => x.User);
        }
    }
}
