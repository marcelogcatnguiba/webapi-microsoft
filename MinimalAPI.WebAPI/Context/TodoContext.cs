namespace MinimalAPI.WebAPI.Context;

public class TodoContext(DbContextOptions<TodoContext> options) : DbContext(options)
{
    public required DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TodosSeedConfiguration());
    }
}