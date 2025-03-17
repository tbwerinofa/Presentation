using BusinessObject.Dtos;
using DataAccess.Core;
using Microsoft.EntityFrameworkCore;

namespace QueryService;

public class QueryTaskStatusRepository: IQueryTaskStatusRepository
{
    #region global fields

    private readonly TaskDbContext dbContext;

    #endregion

    #region CTOR

    public QueryTaskStatusRepository(TaskDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    #endregion

    #region Methods

    public async Task<List<TaskStatusDto>> GetAll()
    {
        var taskList =  dbContext.TaskStatus.IgnoreQueryFilters();

        return await taskList.Select(a => new TaskStatusDto(a.Id, a.Name)).ToListAsync();

    }

    #endregion

}
