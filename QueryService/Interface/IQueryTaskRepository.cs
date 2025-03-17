using BusinessObject.Dtos;

namespace QueryService;

public interface IQueryTaskRepository
{
    Task<List<TaskDto>> GetAll();
    Task<TaskDetailDto> Get(int id);
}
