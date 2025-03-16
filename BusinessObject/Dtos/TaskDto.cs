namespace BusinessObject.Dtos;

public record TaskDto(int id, string title, string? description,int taskEntityStatusId, string status, DateTime? dueDate);

