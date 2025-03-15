
using Microsoft.EntityFrameworkCore;

namespace Presentation.Data;
public class TaskDbContext: DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options):base(options){}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var folder = Environment.SpecialFolder.ApplicationData;
        var path = Environment.GetFolderPath(folder);
        optionsBuilder.UseSqlite($"Data Source={Path.Join(path,"tasks.db")}");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
       SeedData.Seed(builder);
    }
    public DbSet<TaskEntity> Tasks => Set<TaskEntity>();
}