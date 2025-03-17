using DataAccess.EntitySet;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.Core;

public class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") is null)
        {
            //optionsBuilder.UseInMemoryDatabase(new Guid().ToString());
        }
        else
        {
            var folder = Environment.SpecialFolder.ApplicationData;
            var path = Environment.GetFolderPath(folder);
            optionsBuilder.UseSqlite($"Data Source={Path.Join(path, "TaskMgt.db")}");
        }
       
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        SeedData.Seed(builder);

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

    public DbSet<TaskStatusEntity> TaskStatus { get; set; }
    public DbSet<TaskEntity> Tasks { get; set; }

}

