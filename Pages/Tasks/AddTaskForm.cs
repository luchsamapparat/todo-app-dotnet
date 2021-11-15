using System;
using System.ComponentModel.DataAnnotations;
using SsrTodo.Domain;

namespace SsrTodo.Pages.Tasks
{
    public class AddTaskForm
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter a task.")]
        public string Description { get; init; }

        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "Please pick a future date.")]
        public DateTime? DueDate { get; init; }
    }
}
