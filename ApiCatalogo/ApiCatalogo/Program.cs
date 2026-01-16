using ApiCatalogo.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
  options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); // UTILIZADO PARA OBTER DADOS DE DUAS ENTIDADES EM UM MESMO ENDPOINT

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var mysqlConnection = builder.Configuration.GetConnectionString("DefaultConnection")!;

if (string.IsNullOrEmpty(mysqlConnection))
    throw new InvalidOperationException("String de conexão não encontrada.");

builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseMySql(mysqlConnection, 
                    ServerVersion.AutoDetect(mysqlConnection)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
        options.SwaggerEndpoint("/openapi/v1.json", "weather api"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
