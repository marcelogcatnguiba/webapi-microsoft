namespace MinimalAPI.WebAPI.Context.Seed.Todos;

public class TodosSeedConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        List<Todo> todos = 
        [
            new() { Id = 1, Name = "Levar cachorro para passear", IsComplete = false },
            new() { Id = 2, Name = "Dar comida para tartaruga", IsComplete = true },
            new() { Id = 3, Name = "Comprar leite e café", IsComplete = false },
            new() { Id = 4, Name = "Assistir uma serie de TV", IsComplete = true },
            new() { Id = 5, Name = "Ir na casa da Vovo", IsComplete = true },
            new() { Id = 6, Name = "Dar banho no peixe", IsComplete = false }
        ];
        
        builder.HasData(todos);
    }
}