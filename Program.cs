using SystemLab.Middlewares;
using SystemLab.Repositories;
using SystemLab.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<ProdutoRepository>();
builder.Services.AddScoped<ProdutoService>();

builder.Services.AddControllers();     
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseMiddleware<RequestLoggingMiddleware>();
app.MapControllers();



app.Run();

