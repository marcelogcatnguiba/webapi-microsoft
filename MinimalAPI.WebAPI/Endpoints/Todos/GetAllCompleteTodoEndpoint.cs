using Microsoft.EntityFrameworkCore;
using MinimalAPI.WebAPI.Context;
using MinimalAPI.WebAPI.Entities;
using MinimalAPI.WebAPI.Common;

namespace MinimalAPI.WebAPI.Endpoints.Todos
{
    public class GetAllCompleteTodoEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/complete", GetAllCompleteAsync)
                .WithName("Todos: Complete")
                .WithSummary("Recupera todas todos completas")
                .WithDescription("Recupera todas todos completas")
                .WithOrder(6)
                .Produces<List<Todo>>(StatusCodes.Status200OK);
        }

        static async Task<IResult> GetAllCompleteAsync(TodoContext context)
        {
            return TypedResults.Ok(await context.Todos.Where(x => x.IsComplete).ToListAsync());
        }
    }
}