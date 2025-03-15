using CommandService;
using DataAccess.Core;
using Microsoft.EntityFrameworkCore;
using Presentation.Extensions;
using QueryService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors();

builder.Services.AddDbContext<TaskDbContext>(a =>
    a.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddScoped<ICommandTaskRepository, CommandTaskRepository>();
builder.Services.AddScoped<IQueryTaskRepository, QueryTaskRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json","v1"));
}

app.UseCors(a=> a.WithOrigins("http://localhost:3000/")
.AllowAnyHeader()
.AllowAnyMethod()
.AllowAnyOrigin());

app.UseHttpsRedirection();

app.MapTaskEndPoints();

app.Run();

