using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace SsrTodo.Pages;

public static class PagesServiceCollectionExtensions
{
    public static IServiceCollection AddTodoPages(this IServiceCollection services)
    {
        services.AddSingleton<IHtmlGenerator, HtmlGenerator>();
        services.Configure<RouteOptions>(options =>
        {
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = true;
        });
        services
            .AddRazorPages()
            .AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Tasks/Index", "/");
            });
        return services;
    }
}