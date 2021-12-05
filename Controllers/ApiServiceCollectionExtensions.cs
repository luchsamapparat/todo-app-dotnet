using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace SsrTodo.Controllers;

public static class WebServiceCollectionExtensions
{
    public static IServiceCollection AddTodoApi(this IServiceCollection services)
    {
        // Add services to the container.
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var problemDetailsFactory = actionContext.HttpContext.RequestServices.GetRequiredService<ProblemDetailsFactory>();
                var problemDetails = problemDetailsFactory.CreateValidationProblemDetails(actionContext.HttpContext, actionContext.ModelState);
                ObjectResult result;
                if (problemDetails.Status == 400)
                {
                    problemDetails.Status = 422;
                    result = new UnprocessableEntityObjectResult(problemDetails);
                }
                else
                {
                    result = new ObjectResult(problemDetails)
                    {
                        StatusCode = problemDetails.Status,
                    };
                }
                result.ContentTypes.Add("application/problem+json");
                result.ContentTypes.Add("application/problem+xml");
                return result;
            };
        });
        return services;
    }
}