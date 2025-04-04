namespace MinimalAPI.WebAPI.Endpoints.Todos;

public class GetByIdTodoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/{id}", GetAsync)
            .WithName("Todos: GetById")
            .WithSummary("Retorna um Todo pelo Id")
            .WithDescription("Retorna um Todo pelo Id")
            .WithOrder(6)
            .Produces<Todo>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
    }

    private static async Task<IResult> GetAsync(int id, TodoContext context)
    {
        return await context.Todos.FindAsync(id) is Todo todo
            ? TypedResults.Ok(todo)
                : TypedResults.NotFound();
    }
}