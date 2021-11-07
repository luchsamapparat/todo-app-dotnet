using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SsrTodo.Pages
{
    public class CompletedTasksModel : PageModel
    {
        private readonly ILogger<CompletedTasksModel> _logger;

        public CompletedTasksModel(ILogger<CompletedTasksModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
