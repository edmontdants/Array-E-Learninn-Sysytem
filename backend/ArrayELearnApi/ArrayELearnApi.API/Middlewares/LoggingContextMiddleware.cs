using Serilog.Context;
using System.Security.Claims;

namespace ArrayELearnApi.API.Middlewares
{
    public class LoggingContextMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingContextMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            var correlationId = context.TraceIdentifier;
            var userId = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "Anonymous";

            using (LogContext.PushProperty("CorrelationId", correlationId))
            using (LogContext.PushProperty("UserId", userId))
            {
                await _next(context);
            }
        }
    }
}
