using Microsoft.EntityFrameworkCore;
using MinimalAPI.WebAPI.Context.Seed.Todos;
using MinimalAPI.WebAPI.Entities;

namespace MinimalAPI.WebAPI.Context
{
    public class TodoContext(DbContextOptions<TodoContext> options) : DbContext(options)
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodosSeedConfiguration());
        }
    }
}