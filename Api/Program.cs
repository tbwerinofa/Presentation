using AutoMapper;
using BusinessObject.Helpers;
using CommandService;
using DataAccess.Core;
using Microsoft.EntityFrameworkCore;
using Presentation.Exception;
using Presentation.Extensions;
using QueryService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors();

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddDbContext<TaskDbContext>(a =>
{ 
    a.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    a.UseSqlite(x => x.MigrationsAssembly("Presentation"));
    a.EnableSensitiveDataLogging(true);
}
);

builder.Services.AddScoped<ICommandTaskRepository, CommandTaskRepository>();
builder.Services.AddScoped<IQueryTaskRepository, QueryTaskRepository>();

builder.Host.SerilogConfiguration(builder.Configuration.GetValue<string>("LogsPath"));
//builder.Services.AddSerilog();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new TaskProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
app.UseExceptionHandler();


app.Run();

public partial class Program { }