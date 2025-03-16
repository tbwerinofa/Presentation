using BusinessObject.Dtos;
using CommandService;
using DataAccess.Core;
using DataAccess.EntitySet;
using Microsoft.EntityFrameworkCore;
using QueryService;

namespace PresentationTests.Helpers
{
    public class RepositoryHelper: IDisposable
    {
     private readonly TaskDbContext taskDbContext;

    public RepositoryHelper()
    {
        var builder = new DbContextOptionsBuilder<TaskDbContext>();
        builder.UseInMemoryDatabase(databaseName: new Guid().ToString());
        var dbContextOptions = builder.Options;

        taskDbContext = new TaskDbContext(dbContextOptions);

          taskDbContext.ChangeTracker
         .Entries()
         .ToList()
         .ForEach(e => e.State = EntityState.Detached);
            taskDbContext.Database.EnsureDeleted();
        taskDbContext.Database.EnsureCreated();
    }

    public IQueryTaskRepository GetInMemoryReadRepository()
    {
        return new QueryTaskRepository(taskDbContext);
    }

    public ICommandTaskRepository GetInMemoryWriteRepository()
    {
        return new CommandTaskRepository(taskDbContext);
    }

    public IEnumerable<TaskDetailDto> GetTaskList()
        {
            List<TaskStatusEntity> taskStatusEntityList = GetTaskStatusEntityList();

            return new List<TaskDetailDto> {
                new TaskDetailDto(
                    1,
                    "File Import",
                    "I failed to import file",
                    taskStatusEntityList[0].Id,
                    taskStatusEntityList[0].Name,
                    DateTime.Parse("2025-03-23")
                    ),
                new TaskDetailDto(
                    2,
                    "Race Results",
                    "Results are now available",
                    taskStatusEntityList[0].Id,
                    taskStatusEntityList[0].Name,
                    DateTime.Parse("2025-03-16")
                    ),
                new TaskDetailDto(
                    3,
                    "Running Series",
                    "Please import running series data",
                    taskStatusEntityList[0].Id,
                    taskStatusEntityList[0].Name,
                    DateTime.Parse("2025-03-21")
                    )
            };
        }

        private static List<TaskStatusEntity> GetTaskStatusEntityList()
        {
            return new List<TaskStatusEntity>()
            {
                { new TaskStatusEntity(){ Id = 1, Name = "To Do" } },
                { new TaskStatusEntity(){ Id = 2, Name = "In Progress" } },
                { new TaskStatusEntity(){ Id = 3, Name = "Done"} }
            };
        }

        public void Dispose()
        {
            taskDbContext.Database.EnsureDeleted();
            taskDbContext.Dispose();
        }
    }
}
