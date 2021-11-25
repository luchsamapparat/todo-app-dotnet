namespace SsrTodo.Domain;

public class CompletedTasksForm
{
    public IEnumerable<string> CompletedTasks { get; init; } = Enumerable.Empty<string>();
}