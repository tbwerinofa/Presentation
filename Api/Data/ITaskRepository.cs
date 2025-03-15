using Microsoft.EntityFrameworkCore;
using Presentation.Dtos;

namespace Presentation.Data;

    public interface ITaskRepository
    {
    Task<List<TaskDto>> GetAll();
    Task<TaskDetailDto> Get(int id);
    Task<TaskDetailDto> Add(TaskDetailDto dto);

     Task<TaskDetailDto> Update(TaskDetailDto dto);

    Task Delete(int id);

    }
