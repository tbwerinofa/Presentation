using DataAccess.EntitySet;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection;

namespace DataAccess.Core;

public class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var folder = Environment.SpecialFolder.ApplicationData;
        var path = Environment.GetFolderPath(folder);
        optionsBuilder.UseSqlite($"Data Source={Path.Join(path, "TaskMgt.db")}");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //SeedData.Seed(builder);

        var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
        .Where(type => !String.IsNullOrEmpty(type.Namespace))
        .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
        type.BaseType.GetGenericTypeDefinition() == typeof(InsightEntityTypeConfiguration<>));

        foreach (var type in typesToRegister)
        {
            dynamic configurationInstance = Activator.CreateInstance(type);
            builder.ApplyConfiguration(configurationInstance);
        }

        base.OnModelCreating(builder);
    }

    public DbSet<TaskStatusEntity> TaskStatus => Set<TaskStatusEntity>();
    public DbSet<TaskEntity> Tasks => Set<TaskEntity>();

}

