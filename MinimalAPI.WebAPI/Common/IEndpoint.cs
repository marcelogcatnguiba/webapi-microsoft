namespace MinimalAPI.WebAPI.Common
{
    public interface IEndpoint
    {
        static abstract void Map(IEndpointRouteBuilder app);
    }
}