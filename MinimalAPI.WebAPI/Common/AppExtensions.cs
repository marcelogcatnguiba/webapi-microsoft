using MinimalAPI.WebAPI.Context;

namespace MinimalAPI.WebAPI.Common
{
    public static class AppExtensions
    {
        public static void ConfigureDevEnvironment(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapSwagger();
        }

        public static void CreateDatabase(this WebApplication app)
        {
            var serviceScope = app.Services.CreateScope();
            var dataContext = serviceScope.ServiceProvider.GetService<TodoContext>();
            dataContext?.Database.EnsureCreated();
        }
    }
}