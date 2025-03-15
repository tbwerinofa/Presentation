namespace Presentation.Dtos;

public class TaskDto(int id, string title, string? description, string status, DateTime? dueDate)
{

    public int Id { get;} =id;
    public string Title { get;} = title;
    public string? Description { get;} = description;
    public string Status { get;} = status;
    public DateTime? DueDate { get;} = dueDate;
}

