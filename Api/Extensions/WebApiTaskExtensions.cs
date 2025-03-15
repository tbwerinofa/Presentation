﻿using BusinessObject.Dtos;
using CommandService;
using Microsoft.AspNetCore.Mvc;
using MiniValidation;
using QueryService;

namespace Presentation.Extensions;
public static class WebApiTaskExtensions
{
    public static void MapTaskEndPoints(this WebApplication app)
    {
        app.MapGet("/tasks", (IQueryTaskRepository repo) => repo.GetAll())
           .Produces<TaskDto[]>(StatusCodes.Status200OK);

        app.MapGet("/task/{taskId:int}", async (int taskId, IQueryTaskRepository repo) => {
            var taskDetailDto = await repo.Get(taskId);

            if (taskDetailDto == null)
            {
                return Results.Problem($"Task with ID {taskId} not found", statusCode: 404);
            }

            return Results.Ok(taskDetailDto);
        })
           .ProducesProblem(404)
           .Produces<TaskDetailDto>(StatusCodes.Status200OK);

        app.MapPost("/tasks", async ([FromBody] TaskDetailDto dto, ICommandTaskRepository repo) => {

            if (!MiniValidator.TryValidate(dto, out var errors))
                return Results.ValidationProblem(errors);

            var newTask = await repo.Add(dto);

            return Results.Created($"/task/{newTask.id}", newTask);
        })
           .Produces<TaskDetailDto>(StatusCodes.Status201Created)
           .ProducesValidationProblem();

        app.MapPut("/tasks", async ([FromBody] TaskDetailDto dto, IQueryTaskRepository queryRepo, ICommandTaskRepository repo) => {

            if (!MiniValidator.TryValidate(dto, out var errors))
                return Results.ValidationProblem(errors);

            if (await queryRepo.Get(dto.id) == null)
                return Results.Problem($"Task with ID {dto.id} not found", statusCode: 404);

            var updatedTask = await repo.Update(dto);

            return Results.Ok(updatedTask);
        }).ProducesProblem(404)
          .Produces<TaskDetailDto>(StatusCodes.Status200OK)
          .ProducesValidationProblem();

        app.MapDelete("/tasks/{taskId:int}", async (int taskId, IQueryTaskRepository queryRepo, ICommandTaskRepository repo) => {
            var taskDetailDto = await queryRepo.Get(taskId);

            if (taskDetailDto == null)
            {
                return Results.Problem($"Task with ID {taskId} not found", statusCode: 404);
            }

            await repo.Delete(taskDetailDto.id);

            return Results.Ok();
            })
           .ProducesProblem(404)
           .Produces(StatusCodes.Status200OK);
    }
}

