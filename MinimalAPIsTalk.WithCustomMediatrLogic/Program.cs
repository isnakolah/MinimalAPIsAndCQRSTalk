using Microsoft.EntityFrameworkCore;
using MinimalAPIsTalk.WithCustomMediatrLogic.Configurations.Mediator;
using MinimalAPIsTalk.WithCustomMediatrLogic.Configurations.Middlewares;
using MinimalAPIsTalk.WithCustomMediatrLogic.Endpoints.Recipes.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("in-memory-db"));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<Program>();
    cfg.AddOpenBehavior(typeof(ValidationMiddleware<,>));
});

var app = builder.Build();

app.MapEndpoints(typeof(Program));

app.Run();