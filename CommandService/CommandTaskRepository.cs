﻿using BusinessObject.Dtos;
using DataAccess.Core;
using DataAccess.EntitySet;
using Microsoft.EntityFrameworkCore;


namespace CommandService;

public class CommandTaskRepository : ICommandTaskRepository
{
    #region global fields

    private readonly TaskDbContext dbContext;

    #endregion

    #region CTOR

    public CommandTaskRepository(TaskDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    #endregion

    #region Methods

    public async Task<TaskDetailDto> Add(TaskDetailDto dto)
        {
            var entity = new TaskEntity();
            DtoToEntity(dto, entity);

            dbContext.Tasks.Add(entity);
            await dbContext.SaveChangesAsync();

            return EntityToTaskDetailDto(entity);
        }

    public async Task<TaskDetailDto> Update(TaskDetailDto dto)
    {
        var entity = await dbContext.Tasks.FindAsync(dto.id);

        if (entity == null)
            throw new ArgumentException($"Error update task {dto.id}");

        DtoToEntity(dto, entity);

        dbContext.Entry(entity).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();

        return EntityToTaskDetailDto(entity);
    }

    public async Task Delete(int id)
    {
        var entity = await dbContext.Tasks.FindAsync(id);

        if (entity == null)
            throw new ArgumentException($"Error deleting task {id}");

        dbContext.Tasks.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    private static TaskDetailDto EntityToTaskDetailDto(TaskEntity entity)
    {
        return new TaskDetailDto(entity.Id, entity.Title, entity.Description,entity.TaskStatusEntityId, entity.TaskStatusEntity.Name, entity.DueDate);
    }

    private static void DtoToEntity(TaskDetailDto dto, TaskEntity entity)
    {
        entity.Title = dto.title;
        entity.Description = dto.description;
        entity.TaskStatusEntityId = dto.taskStatusEntityId;
        entity.DueDate = dto.dueDate;
    }
    
    #endregion
}
