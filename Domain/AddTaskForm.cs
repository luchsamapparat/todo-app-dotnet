using System.ComponentModel.DataAnnotations;
using SsrTodo.Common;

namespace SsrTodo.Domain;

public class AddTaskForm
{
    [Required]
    [MinLength(1, ErrorMessage = "Please enter a task.")]
    public string Description { get; init; } = string.Empty;

    [DataType(DataType.Date)]
    [FutureDate(ErrorMessage = "Please pick a future date.")]
    public DateTime? DueDate { get; init; }

}