using AutoMapper;
using BusinessObject.Dtos;
using DataAccess.Core;
using DataAccess.EntitySet;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace QueryService;

public class QueryTaskRepository: IQueryTaskRepository
{
    #region global fields

    private readonly TaskDbContext dbContext;

    #endregion

    #region CTOR

    public QueryTaskRepository(TaskDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    #endregion

    #region Methods

    public async Task<List<TaskDto>> GetAll()
    {
        var taskList =  dbContext.Tasks.Include(a=> a.TaskStatusEntity).IgnoreQueryFilters();

        //return _mapper.Map<List<TaskDto>>(taskList);

        return await taskList.Select(a => new TaskDto(a.Id, a.Title, a.Description, a.TaskStatusEntity.Id, a.TaskStatusEntity.Name, a.DueDate)).ToListAsync();

    }
    public async Task<TaskDetailDto> Get(int id)
    {
        var entity = await dbContext.Tasks.Include(a=>a.TaskStatusEntity).SingleOrDefaultAsync(a => a.Id == id);

        if (entity == null)
            return null;

        return EntityToTaskDetailDto(entity);
    }

    private static TaskDetailDto EntityToTaskDetailDto(TaskEntity entity)
    {
        return new TaskDetailDto(entity.Id, entity.Title, entity.Description, entity.TaskStatusEntityId, entity.TaskStatusEntity.Name, entity.DueDate);
    }

    #endregion

}
