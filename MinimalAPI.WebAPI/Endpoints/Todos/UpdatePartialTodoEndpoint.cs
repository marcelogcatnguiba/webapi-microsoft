using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MinimalAPI.WebAPI.Endpoints.Todos;

public class UpdatePartialTodoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPatch("/{id}", UpdatePartialAsync)
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status422UnprocessableEntity);
    }

    private static async Task<IResult> UpdatePartialAsync(int id, [FromBody] JsonPatchDocument<Todo> patchDocument, TodoContext context)
    {
        if(patchDocument == null)
        {
            return Results.BadRequest();
        }

        var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id.Equals(id));

        if(todo == null)
        {
            return Results.NotFound();
        }

        try
        {
            patchDocument.ApplyTo(todo);
            
            return Results.NoContent();
        }
        catch (Exception)
        {
            return Results.UnprocessableEntity();
        }
    }
}
