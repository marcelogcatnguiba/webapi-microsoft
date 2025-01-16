namespace MinimalAPI.WebAPI.Endpoints.HealthCheck;

public class HealthCheckEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app
        .MapGroup("/")
        .WithTags("Health Check")
        .MapGet("/", () => 
            new Message(true));
    }
}

record Message(bool CanAccess);