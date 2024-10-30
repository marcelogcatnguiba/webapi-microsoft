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
    }
}