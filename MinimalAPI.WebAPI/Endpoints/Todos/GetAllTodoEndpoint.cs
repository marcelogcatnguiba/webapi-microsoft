namespace MinimalAPI.WebAPI.Endpoints.Todos;

public class GetAllTodoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/", GetAllAsync)
            .WithName("Todos: GetAll")
            .WithSummary("Recupera todas Todos")
            .WithDescription("Recupera todas Todos")
            .WithOrder(5)
            .Produces<List<Todo>>(StatusCodes.Status200OK);
    }

    static async Task<IResult> GetAllAsync(TodoContext context)
    {
        return TypedResults.Ok(await context.Todos.ToListAsync());
    }
}