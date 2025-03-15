using Microsoft.EntityFrameworkCore;
using Presentation.Dtos;

namespace Presentation.Data;

public class TaskRepository: ITaskRepository
{ 
    private readonly TaskDbContext dbContext;

    public TaskRepository(TaskDbContext dbContext)
	{
        this.dbContext = dbContext;
    }

    public async Task<List<TaskDto>> GetAll()
    {
        return await dbContext.Tasks.Select(a => new TaskDto(a.Id, a.Title, a.Description, a.Status, a.DueDate)).ToListAsync();
    }
    public async Task<TaskDetailDto> Get(int id)
    {
        var entity =  await dbContext.Tasks.SingleOrDefaultAsync(a => a.Id == id);

        if(entity == null)
            return null;

        return EntityToTaskDetailDto(entity);
    }

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
        return new TaskDetailDto(entity.Id, entity.Title, entity.Description, entity.Status, entity.DueDate);
    }
    private static void DtoToEntity(TaskDetailDto dto, TaskEntity entity)
    {
        entity.Title = dto.title;
        entity.Description = dto.description;
        entity.Status = dto.status;
        entity.DueDate = dto.dueDate;
    }
}

