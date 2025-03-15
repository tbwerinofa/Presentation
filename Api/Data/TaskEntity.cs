using System.ComponentModel.DataAnnotations;
namespace Presentation.Data;
public class TaskEntity{
    [Key]
    public int Id {get;set;}
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
}