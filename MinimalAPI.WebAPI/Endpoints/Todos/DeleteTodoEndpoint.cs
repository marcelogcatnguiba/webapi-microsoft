using MinimalAPI.WebAPI.Context;
using MinimalAPI.WebAPI.Entities;
using MinimalAPI.WebAPI.Common;

namespace MinimalAPI.WebAPI.Endpoints.Todos
{
    public class DeleteTodoEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapDelete("/{id}", DeleteAsync)
                .WithName("Todos: Delete")
                .WithSummary("Delete uma Todo")
                .WithDescription("Delete uma Todo")
                .WithOrder(3)
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);
        }

        static async Task<IResult> DeleteAsync(int id, TodoContext contexto)
        {
            if (await contexto.Todos.FindAsync(id) is Todo todo)
            {
                contexto.Todos.Remove(todo);
                await contexto.SaveChangesAsync();

                return TypedResults.Ok();
            }

            return TypedResults.NotFound();
        }
    }
}