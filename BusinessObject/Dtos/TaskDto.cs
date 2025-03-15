namespace BusinessObject.Dtos;

public record TaskDto(int id, string title, string? description, string status, DateTime? dueDate);

