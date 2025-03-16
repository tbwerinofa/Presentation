using BusinessObject.Dtos;
using CommandService;
using Microsoft.AspNetCore.Mvc;
using MiniValidation;
using QueryService;
using Serilog;
using System.Threading.Tasks;

namespace Presentation.Extensions;
public static class WebApiTaskExtensions
{
    public static void MapTaskEndPoints(this WebApplication app)
    {
        app.MapGet("/tasks", (IQueryTaskRepository repo) => {
            try
            {
                Log.Information("Tasks processing has started");

                return repo.GetAll();
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Unable to get tasks");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        })
           .Produces<TaskDto[]>(StatusCodes.Status200OK);

        app.MapGet("/task/{taskId:int}", async (int taskId, IQueryTaskRepository repo) => {

            try
            {
                Log.Information($"Tasks processing has started for taskId:{taskId}");

                var taskDetailDto = await repo.Get(taskId);

                if (taskDetailDto == null)
                {
                    return Results.Problem($"Task with ID {taskId} not found", statusCode: 404);
                }

                return Results.Ok(taskDetailDto);
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, $"Unable to get taskId:{taskId}");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }

        })
           .ProducesProblem(404)
           .Produces<TaskDetailDto>(StatusCodes.Status200OK);

        app.MapPost("/tasks", async ([FromBody] TaskDetailDto dto, ICommandTaskRepository repo) => {

            try
            {
                Log.Information($"Task: Create new record");


                if (!MiniValidator.TryValidate(dto, out var errors))
                    return Results.ValidationProblem(errors);

                var newTask = await repo.AddAsync(dto);

                return Results.Created($"/task/{newTask.id}", newTask);
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Unable to create new task");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        })
           .Produces<TaskDetailDto>(StatusCodes.Status201Created)
           .ProducesValidationProblem();

        app.MapPut("/tasks", async ([FromBody] TaskDetailDto dto, IQueryTaskRepository queryRepo, ICommandTaskRepository repo) => {
            try
            {
                Log.Information($"Task: Update record taskid: {dto.id}");

                if (!MiniValidator.TryValidate(dto, out var errors))
                    return Results.ValidationProblem(errors);

                if (await queryRepo.Get(dto.id) == null)
                    return Results.Problem($"Task with ID {dto.id} not found", statusCode: 404);

                var updatedTask = await repo.UpdateAsync(dto);

                return Results.Ok(updatedTask);
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, $"Task: Unable to update taskid {dto.id}");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
           
        }).ProducesProblem(404)
          .Produces<TaskDetailDto>(StatusCodes.Status200OK)
          .ProducesValidationProblem();

        app.MapDelete("/tasks/{taskId:int}", async (int taskId, IQueryTaskRepository queryRepo, ICommandTaskRepository repo) => {
            try
            {
                Log.Information($"Task: Delete record, Task with ID: {taskId}");

                var taskDetailDto = await queryRepo.Get(taskId);

                if (taskDetailDto == null)
                {
                    return Results.Problem($"Task with ID {taskId} not found", statusCode: 404);
                }

                await repo.DeleteAsync(taskDetailDto.id);

                return Results.Ok();
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, $"Task: Unable to delete task with ID: {taskId}");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }

            })
           .ProducesProblem(404)
           .Produces(StatusCodes.Status200OK);
    }
}

