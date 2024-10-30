using Microsoft.EntityFrameworkCore;
using MinimalAPI.WebAPI.Entities;

namespace MinimalAPI.WebAPI.Context
{
    public class TodoContext(DbContextOptions<TodoContext> options) : DbContext(options)
    {
        public DbSet<Todo> Todos { get; set; }
    }
}