var builder = WebApplication.CreateBuilder(args);

builder.AddDatabase();
builder.AddDocumentation();
builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseHttpsRedirection();
app.MapEndpoints();
app.CreateDatabase();

app.Run();