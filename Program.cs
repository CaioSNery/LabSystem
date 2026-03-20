using LabSystem.Background;
using LabSystem.Middlewares;
using SystemLab.Infrastructure;
using SystemLab.Middlewares;
using SystemLab.Repositories;
using SystemLab.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddSingleton<ProdutoRepository>();
builder.Services.AddScoped<ProdutoService>();

builder.Services.AddControllers();
builder.Services.AddAuthorization();

builder.Services.AddHostedService<PedidoWorker>();

builder.Services.AddSingleton<FilaPedidos>();

builder.Services.AddMemoryCache();

var app = builder.Build();



app.UseAuthorization();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();
app.MapControllers();



app.Run();

