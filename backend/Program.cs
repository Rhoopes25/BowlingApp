using Microsoft.EntityFrameworkCore;
using BowlingAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Register controllers so .NET knows to look for API controllers
builder.Services.AddControllers();
builder.Services.AddCors();

// Register BowlingContext with SQLite using connection string from appsettings.json
builder.Services.AddDbContext<BowlingContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BowlingConnection")));

// Add OpenAPI/Swagger documentation
builder.Services.AddOpenApi();

var app = builder.Build();

// Only show API docs in development mode
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Allow React app on port 3000 to make requests to this API
// Without this, the browser would block all requests from React
app.UseCors(x => x
    .WithOrigins("http://localhost:3000")
    .AllowAnyMethod()
    .AllowAnyHeader());

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Enable authorization middleware
app.UseAuthorization();

// Map controller routes so API endpoints are accessible
app.MapControllers();

app.Run();