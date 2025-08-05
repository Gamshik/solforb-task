using backend.Middleware;
using ORMAdapter.Contexts;
using ORMAdapter.DependencyInjection;
using ORMAdapter.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDBService(builder.Configuration);

builder.Services.RegisterRepositories();

builder.Services.RegisterDbServices();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var app = builder.Build();

app.MigrateDatabase<WarehouseDbContext>();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UsePathBase("/api");

app.UseRouting();

app.MapControllers();

app.Run();
