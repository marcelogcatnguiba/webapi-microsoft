using MinimalAPI.WebAPI.Context;
using MinimalAPI.WebAPI.Entities;
using MinimalAPI.WebAPI.Common;


namespace MinimalAPI.WebAPI.Endpoints.Todos
{
    public class CreateTodoEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("/", CreateAsync)
                .WithName("Todos: Create")
                .WithSummary("Create todos")
                .WithDescription("Create todos")
                .WithOrder(1)
                .Produces<Todo>(StatusCodes.Status201Created);
        }

        static async Task<IResult> CreateAsync(Todo todo, TodoContext contexto)
        {
            contexto.Todos.Add(todo);
            await contexto.SaveChangesAsync();

            return TypedResults.Created($"/todoitems/{todo.Id}", todo);
        }
    }
}