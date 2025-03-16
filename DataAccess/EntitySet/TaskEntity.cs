using System.ComponentModel.DataAnnotations;

namespace DataAccess.EntitySet;

public class TaskEntity{

    [Key]
    public int Id {get;set;}
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }

    public int TaskStatusEntityId { get; set; }
    public virtual TaskStatusEntity TaskStatusEntity { get; set; } = new TaskStatusEntity();
    public DateTime? DueDate { get; set; }
}