using DataAccess.EntitySet;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Core;

public static class SeedData
{
    public static void Seed(ModelBuilder builder)
    {
        var taskStatusEntityList = new List<TaskStatusEntity> {
            new TaskStatusEntity{
                Id = 1,
                Name = "To Do"
                },
            new TaskStatusEntity{
                Id = 2,
                Name = "In Progress",
                },
            new TaskStatusEntity{
                Id = 3,
                Name = "Done"
                } };

        foreach (var item in taskStatusEntityList)
        {

            if (item.Id < 2)
            {
                item.TaskEntities.Add(
            new TaskEntity
            {
                Id = 1,
                Title = "File Import",
                Description = "I failed to import file",
                TaskStatusEntityId = item.Id,
                DueDate = DateTime.Parse("2025-03-23")
            });

                item.TaskEntities.Add(new TaskEntity
                {
                    Id = 2,
                    Title = "Race Results",
                    Description = "Results are now available",
                    TaskStatusEntityId = item.Id,
                    DueDate = DateTime.Parse("2025-03-16")
                });
            }
            else
            {
                item.TaskEntities.Add(new TaskEntity
                {
                    Id = 3,
                    Title = "Running Series",
                    Description = "Please import running series data",
                    TaskStatusEntityId = item.Id,
                    DueDate = DateTime.Parse("2025-03-21")
                });

            }
        }
        builder.Entity<TaskStatusEntity>().HasData(taskStatusEntityList);


        //builder.Entity<TaskEntity>().HasData(new List<TaskEntity> {
        //    new TaskEntity{
        //        Id = 1,
        //        Title = "File Import",
        //        Description = "I failed to import file",
        //        TaskStatusEntityId = 1,
        //        DueDate = DateTime.Parse("2025-03-23")
        //        },
        //    new TaskEntity{
        //        Id = 2,
        //        Title = "Race Results",
        //        Description = "Results are now available",
        //        TaskStatusEntityId = 2,
        //        DueDate = DateTime.Parse("2025-03-16")
        //        },
        //    new TaskEntity{
        //        Id = 3,
        //        Title = "Running Series",
        //        Description = "Please import running series data",
        //        TaskStatusEntityId = 1,
        //        DueDate = DateTime.Parse("2025-03-21")
        //        }
        //});
    }
}

