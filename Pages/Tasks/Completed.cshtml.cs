﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SsrTodo.Domain;

namespace SsrTodo.Pages.Tasks;

public class CompletedTasksModel : PageModel
{
    private readonly TodoListService _todoListService;
    private readonly ILogger<CompletedTasksModel> _logger;

    public CompletedTasksModel(
        TodoListService todoListService,
        ILogger<CompletedTasksModel> logger
    )
    {
        _todoListService = todoListService;
        _logger = logger;
    }

    public ICollection<Domain.Task> CompletedTasks = Array.Empty<Domain.Task>();

    public void OnGet()
    {
        CompletedTasks = _todoListService.GetCompletedTasks();
    }

    public IActionResult OnPost(IEnumerable<string> completedTasks)
    {
        _todoListService.CompleteTasks(completedTasks);
        return Redirect("/");
    }
}