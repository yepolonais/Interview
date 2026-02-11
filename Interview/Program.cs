using Interview.Application.Interfaces;
using Interview.Application.Services;
using Interview.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// Application DI
builder.Services.AddScoped<ICandidateRepository, InMemoryCandidateRepository>();
builder.Services.AddScoped<CandidateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

// Expose Program class for integration testing
public partial class Program { }

