using BusinessObject.Dtos;

namespace QueryService;

public interface IQueryTaskStatusRepository
{
    Task<List<TaskStatusDto>> GetAll();
}
