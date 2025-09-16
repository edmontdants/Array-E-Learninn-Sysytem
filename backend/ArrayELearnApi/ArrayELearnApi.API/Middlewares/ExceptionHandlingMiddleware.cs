using System.Net;
using System.Text.Json;

namespace ArrayELearnApi.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    
                    _logger.LogError(ex, "Unhandled error");

                    // Detailed error response for development environment
                    var devResponse = new
                    {
                        error = ex.Message,
                        detail = ex.StackTrace
                    };
                    await context.Response.WriteAsync(JsonSerializer.Serialize(devResponse));
                }
                else if (_env.IsProduction())
                {
                    _logger.LogError(ex, "Unhandled exception with ID: {ErrorId}", ex.Message);

                    // Simplified error response for production
                    var prodResponse = new
                    {
                        error = "An unexpected error occurred. Please contact support with Error ID: "
                    };
                    await context.Response.WriteAsJsonAsync(prodResponse);
                }
            }
        }
    }
}
