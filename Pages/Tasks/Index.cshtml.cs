using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SsrTodo.Domain;

namespace SsrTodo.Pages.Tasks;

public class IndexModel : PageModel
{
    private readonly TodoListService _todoListService;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(
        TodoListService todoListService,
        ILogger<IndexModel> logger
    )
    {
        _todoListService = todoListService;
        _logger = logger;
    }

    public ICollection<Domain.Task> Tasks = Array.Empty<Domain.Task>();

    public AddTaskForm AddTaskForm = new AddTaskForm();

    public void OnGet()
    {
        Tasks = _todoListService.GetTasks();
    }

    public IActionResult OnPost(AddTaskForm addTaskForm)
    {
        if (!ModelState.IsValid)
        {
            Tasks = _todoListService.GetTasks();
            AddTaskForm = addTaskForm;
            return Page();
        }

        _todoListService.AddTask(addTaskForm.Description, addTaskForm.DueDate);
        return Redirect("/");
    }

}