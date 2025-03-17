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
                }
        };

        builder.Entity<TaskStatusEntity>().HasData(taskStatusEntityList);

    }
}

