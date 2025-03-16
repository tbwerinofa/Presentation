using AutoMapper;
using BusinessObject.Dtos;
using DataAccess.Core;
using DataAccess.EntitySet;
using Microsoft.EntityFrameworkCore;

namespace QueryService;

public class QueryTaskRepository: IQueryTaskRepository
{
    #region global fields

    private readonly TaskDbContext dbContext;
    private readonly IMapper _mapper;

    #endregion

    #region CTOR

    public QueryTaskRepository(TaskDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this._mapper = mapper;
    }

    #endregion

    #region Methods

    public async Task<List<TaskDto>> GetAll()
    {
        var taskList =  dbContext.Tasks;

        //return _mapper.Map<List<TaskDto>>(taskList);

        return await taskList.Select(a => new TaskDto(a.Id, a.Title, a.Description, a.TaskStatusEntity.Name, a.DueDate)).ToListAsync();

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
        return new TaskDetailDto(entity.Id, entity.Title, entity.Description, entity.TaskStatusEntityId, entity.TaskStatusEntity.Name, entity.DueDate);
    }

    #endregion

}
