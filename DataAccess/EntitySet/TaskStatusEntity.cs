using System.ComponentModel.DataAnnotations;

namespace DataAccess.EntitySet;
public class TaskStatusEntity
{
    public TaskStatusEntity()
    {
        this.TaskEntities = [];
    }

    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<TaskEntity> TaskEntities { get; set; }
}

