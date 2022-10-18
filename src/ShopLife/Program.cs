using ShopLife.Application.DiExtension;
using ShopLife.Application.InfraTool.Example;
using ShopLife.Infrastructure.Example;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument();
//builder.Services.AddSwaggerDocument();

// µù¥U½d¨Ò
builder.Services.AddTransient<IExampleService, ExampleService>();
builder.Services.AddApplication();

builder.Services.AddControllers();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
