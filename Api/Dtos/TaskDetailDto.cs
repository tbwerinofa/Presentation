using System.ComponentModel.DataAnnotations;

namespace Presentation.Dtos;

public record TaskDetailDto(int id,[property:Required] string title, string? description, [property: Required] string status, DateTime? dueDate);

