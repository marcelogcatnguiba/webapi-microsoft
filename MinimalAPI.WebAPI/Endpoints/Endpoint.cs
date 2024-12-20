namespace MinimalAPI.WebAPI.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");
        
        endpoints
            .MapGroup("/")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "OK"});

        endpoints
            .MapGroup("v1/todos")
            .WithTags("Todos")
                .MapEndpoint<CreateTodoEndpoint>()
                .MapEndpoint<UpdateTodoEndpoint>()
                .MapEndpoint<DeleteTodoEndpoint>()
                .MapEndpoint<GetAllTodoEndpoint>()
                .MapEndpoint<GetByIdTodoEndpoint>()
                .MapEndpoint<GetAllCompleteTodoEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<T>(this IEndpointRouteBuilder app)
        where T : IEndpoint
    {
        T.Map(app);
        return app;
    }
}