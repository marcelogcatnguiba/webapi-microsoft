using Microsoft.EntityFrameworkCore;
using MinimalAPI.WebAPI.Context;
using MinimalAPI.WebAPI.Entities;

namespace MinimalAPI.WebAPI.Endpoints
{
    public static class TodoEndpoints
    {
        public static WebApplication AddTodoEndpoints(this WebApplication app)
        {
            var todoItems = app.MapGroup("/todoitems");

            todoItems.MapGet("/{id}", Get);
            todoItems.MapGet("/", GetAll);
            todoItems.MapGet("/complete", GetAllComplete);
            todoItems.MapPost("/", Create);
            todoItems.MapPut("/{id}", Update);
            todoItems.MapDelete("/{id}", Delete);

            static async Task<IResult> Get(int id, TodoContext context)
            {
                return await context.Todos.FindAsync(id)
                    is Todo todo
                    ? TypedResults.Ok(todo)
                    : TypedResults.NotFound();
            }

            static async Task<IResult> GetAll(TodoContext context)
            {
                return TypedResults.Ok(await context.Todos.ToListAsync());
            }

            static async Task<IResult> GetAllComplete(TodoContext context)
            {
                return TypedResults.Ok(await context.Todos.Where(x => x.IsComplete).ToListAsync());
            }

            static async Task<IResult> Create(Todo todo, TodoContext contexto)
            {
                contexto.Todos.Add(todo);
                await contexto.SaveChangesAsync();

                return TypedResults.Created($"/todoitems/{todo.Id}", todo);
            }

            static async Task<IResult> Update(int id, Todo inputTodo, TodoContext contexto)
            {
                var todo = await contexto.Todos.FindAsync(id);
                if (todo is null) return Results.NotFound();

                todo.Name = inputTodo.Name;
                todo.IsComplete = inputTodo.IsComplete;

                await contexto.SaveChangesAsync();
                return TypedResults.NoContent();
            }

            static async Task<IResult> Delete(int id, TodoContext contexto)
            {
                if (await contexto.Todos.FindAsync(id) is Todo todo)
                {
                    contexto.Todos.Remove(todo);
                    await contexto.SaveChangesAsync();

                    return TypedResults.NoContent();
                }

                return TypedResults.NotFound();
            }

            return app;
        }
    }
}