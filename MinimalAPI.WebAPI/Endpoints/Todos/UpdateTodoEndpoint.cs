namespace MinimalAPI.WebAPI.Endpoints.Todos;

public class UpdateTodoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("/{id}", UpdateAsync)
            .WithName("Todos: Update")
            .WithSummary("Atualiza uma Todo")
            .WithDescription("Atualiza uma Todo")
            .WithOrder(2)
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status404NotFound);
    }

    static async Task<IResult> UpdateAsync(int id, Todo inputTodo, TodoContext contexto)
        {
            var todo = await contexto.Todos.FindAsync(id);
            
            if (todo is null) 
                return Results.NotFound();

            todo.Name = inputTodo.Name;
            todo.IsComplete = inputTodo.IsComplete;
            await contexto.SaveChangesAsync();

            return TypedResults.Created();
        }
}