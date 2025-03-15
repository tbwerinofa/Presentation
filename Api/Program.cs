using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniValidation;
using Presentation.Data;
using Presentation.Dtos;
using Presentation.Extensions;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors();

builder.Services.AddDbContext<TaskDbContext>(a =>
    a.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddScoped<ITaskRepository,TaskRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors(a=> a.WithOrigins("http://localhost:3000/")
.AllowAnyHeader()
.AllowAnyMethod()
.AllowAnyOrigin());

app.UseHttpsRedirection();

app.MapTaskEndPoints();

app.Run();

