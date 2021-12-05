namespace SsrTodo.Domain;

public static class TodoListServiceCollectionExtensions
{
    public static IServiceCollection AddTodoServices(this IServiceCollection services)
    {
        services.AddSingleton<TodoListService>();
        return services;
    }
}