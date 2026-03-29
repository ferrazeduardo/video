using Catalogo.Application.DependencyInjection;
using Catalogo.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddUseCases();
builder.Services.AddControllers();
var app = builder.Build();


app.SwaggerDocumentation();
app.UseHttpsRedirection();

app.Run();

