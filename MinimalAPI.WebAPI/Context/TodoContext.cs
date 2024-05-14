using Microsoft.EntityFrameworkCore;
using MinimalAPI.WebAPI.Entities;

namespace MinimalAPI.WebAPI.Context
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }
    }
}