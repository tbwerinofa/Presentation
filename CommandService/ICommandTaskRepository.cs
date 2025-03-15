using BusinessObject.Dtos;

namespace CommandService;

public interface ICommandTaskRepository
{
    Task<TaskDetailDto> Add(TaskDetailDto dto);
    Task<TaskDetailDto> Update(TaskDetailDto dto);
    Task Delete(int id);
}
