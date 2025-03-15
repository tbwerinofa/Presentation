using BusinessObject.Dtos;
using DataAccess.Core;
using DataAccess.EntitySet;
using Microsoft.EntityFrameworkCore;

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
        return await dbContext.Tasks.Select(a => new TaskDto(a.Id, a.Title, a.Description, a.Status, a.DueDate)).ToListAsync();
    }
    public async Task<TaskDetailDto> Get(int id)
    {
        var entity = await dbContext.Tasks.SingleOrDefaultAsync(a => a.Id == id);

        if (entity == null)
            return null;

        return EntityToTaskDetailDto(entity);
    }

    private static TaskDetailDto EntityToTaskDetailDto(TaskEntity entity)
    {
        return new TaskDetailDto(entity.Id, entity.Title, entity.Description, entity.Status, entity.DueDate);
    }

    #endregion

}
