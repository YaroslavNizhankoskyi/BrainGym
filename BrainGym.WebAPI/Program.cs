using BrainGym.Application;
using BrainGym.Application.Common.Interfaces;
using BrainGym.Infrastructure;
using BrainGym.WebAPI.Helpers;
using BrainGym.WebAPI.Helpers.Seed;
using BrainGym.WebAPI.Middleware;
using BrainGym.WebAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ICurrentUserService, CurrentUserService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddAppAuthentication(builder.Configuration);
builder.Services.AddAppAuthorization();

var app = builder.Build();

await app.MigrateDb();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
