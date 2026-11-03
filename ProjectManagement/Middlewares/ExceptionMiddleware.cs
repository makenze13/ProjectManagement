namespace ProjectManagement.Middlewares
{
    public class ExceptionMiddleware (RequestDelegate requestDelegate, ILogger<ExceptionMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ошибка");

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(new
                {
                    message = "Внутренняя ошибка сервера"
                });
            }
        }
    }
}
