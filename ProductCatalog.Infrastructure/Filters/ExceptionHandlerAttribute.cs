using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using ProductCatalog.Core.Helpers;
using System.Threading.Tasks;

namespace ProductCatalog.Infrastructure.Filters
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<ExceptionHandlerAttribute> _logger;

        public ExceptionHandlerAttribute(ILogger<ExceptionHandlerAttribute> logger)
        {
            _logger = logger;
        }

        public override Task OnExceptionAsync(ExceptionContext context)
        {
            _logger.LogError(context.Exception.InnerException.Message);

            context.Result = GetResult(context);

            return Task.CompletedTask;
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception.InnerException.Message);

            context.Result = GetResult(context);
        }

        private static IActionResult GetResult(ExceptionContext context) => context.Exception switch
        {
            AppException => new BadRequestObjectResult(new { context.Exception.Message }),
            _ => new BadRequestObjectResult(new { context.Exception.Message })
        };
    }
}
