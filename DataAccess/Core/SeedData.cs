using DataAccess.EntitySet;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Core;

public static class SeedData
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<TaskEntity>().HasData(new List<TaskEntity> {
            new TaskEntity{
                Id = 1,
                Title = "File Import",
                Description = "I failed to import file",
                Status ="To Do",
                DueDate = DateTime.Parse("2025-03-12")
                },
            new TaskEntity{
                Id = 2,
                Title = "Race Results",
                Description = "Results are now available",
                Status ="To Do",
                DueDate = DateTime.Parse("2025-03-16")
                },
            new TaskEntity{
                Id = 3,
                Title = "Running Series",
                Description = "Please import running series data",
                Status ="To Do",
                DueDate = DateTime.Parse("2025-03-21")
                }
        });
    }
}

