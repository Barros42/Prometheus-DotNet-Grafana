using dotnet.Context;
using dotnet.Repositories;
using Microsoft.EntityFrameworkCore;
using Prometheus;
using Prometheus.SystemMetrics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSystemMetrics();

builder.Services.AddDbContext<DatabaseContext>(x => x.UseInMemoryDatabase(databaseName: "BarrosDb"));

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

app.UseMetricServer();
app.UseHttpMetrics();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

