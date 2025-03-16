using BusinessObject.Dtos;

namespace CommandService;

public interface ICommandTaskRepository
{
    Task<TaskDetailDto> AddAsync(TaskDetailDto dto);
    Task<TaskDetailDto> UpdateAsync(TaskDetailDto dto);
    Task DeleteAsync(int id);
}
