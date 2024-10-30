using MinimalAPI.WebAPI.Common;
using MinimalAPI.WebAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.AddDatabase();
builder.AddDocumentation();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseHttpsRedirection();
app.MapEndpoints();

app.Run();