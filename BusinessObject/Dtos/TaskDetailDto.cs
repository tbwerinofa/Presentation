using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Dtos;

public record TaskDetailDto(int id,[property:Required] string title, string? description, [property: Required] string status, DateTime? dueDate);

