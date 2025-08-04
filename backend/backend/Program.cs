using backend.Middleware;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UsePathBase("/api");

app.UseRouting();

app.MapControllers();

app.Run();
