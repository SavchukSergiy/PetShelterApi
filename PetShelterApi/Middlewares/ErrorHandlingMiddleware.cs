using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace PetShelterApi.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // Пускаємо запит далі по пайплайну
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message); // Логувати помилку
                await HandleExceptionAsync(context, ex); // Повернути відповідь
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 помилка за замовчуванням

            var result = JsonSerializer.Serialize(new
            {
                error = exception.Message,
                stackTrace = exception.StackTrace // !!! У реальному продакшн краще це не повертати
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }

    }
}
