using Microsoft.AspNetCore.Mvc;
using SsrTodo.Domain;

namespace SsrTodo.Controllers;

[ApiController]
[Route("api/tasks")]
public class TodoApiController : ControllerBase
{
    private readonly TodoListService _todoListService;
    private readonly ILogger<TodoApiController> _logger;

    public TodoApiController(
        TodoListService todoListService,
        ILogger<TodoApiController> logger
    )
    {
        _todoListService = todoListService;
        _logger = logger;
    }

    [HttpGet()]
    public IEnumerable<SsrTodo.Domain.Task> GetTasks()
    {
        return _todoListService.GetTasks();
    }

    [HttpPost()]
    public IActionResult AddTask(AddTaskForm addTaskForm)
    {
        _todoListService.AddTask(addTaskForm.Description, addTaskForm.DueDate);
        return CreatedAtAction(nameof(GetTasks), null);
    }

    [HttpGet("completed")]
    public IEnumerable<SsrTodo.Domain.Task> GetCompletedTasks()
    {
        return _todoListService.GetCompletedTasks();
    }

    [HttpPost("completed")]
    public IActionResult CompleteTasks(CompletedTasksForm completedTasksForm)
    {
        _todoListService.CompleteTasks(completedTasksForm.CompletedTasks);
        return SeeOther("/api/tasks");
    }

    private IActionResult SeeOther(string location)
    {
        Response.Headers.Add("Location", location);
        return new StatusCodeResult(303);
    }
}
