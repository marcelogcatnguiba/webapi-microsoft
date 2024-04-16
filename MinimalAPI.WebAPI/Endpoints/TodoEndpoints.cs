using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
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
            todoItems.MapGet("/", async (TodoContext context) =>
                await context.Todos.ToListAsync());

            todoItems.MapGet("/complete", async (TodoContext context) =>
                await context.Todos.Where(x => x.IsComplete).ToListAsync());

            todoItems.MapGet("/{id}", async (int id, TodoContext context) =>
                await context.Todos.FindAsync(id)
                    is Todo todo
                    ? Results.Ok(todo)
                    : Results.NotFound());

            todoItems.MapPost("/", async (Todo todo, TodoContext contexto) =>
            {
                contexto.Todos.Add(todo);
                await contexto.SaveChangesAsync();

                return Results.Created($"/todoitems/{todo.Id}", todo);
            });

            todoItems.MapPut("/{id}", async (int id, Todo inputTodo, TodoContext contexto) =>
            {
                var todo = await contexto.Todos.FindAsync(id);
                if (todo is null) return Results.NotFound();

                todo.Name = inputTodo.Name;
                todo.IsComplete = inputTodo.IsComplete;

                await contexto.SaveChangesAsync();
                return Results.NoContent();
            });

            todoItems.MapDelete("/{id}", async (int id, TodoContext context) =>
            {
                if (await context.Todos.FindAsync(id) is Todo todo)
                {
                    context.Todos.Remove(todo);
                    await context.SaveChangesAsync();

                    return Results.NoContent();
                }

                return Results.NotFound();
            });
            return app;
        }
    }
}