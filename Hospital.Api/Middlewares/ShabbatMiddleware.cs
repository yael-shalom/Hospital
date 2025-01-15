namespace Hospital.Api.Middlewares
{
    public class ShabbatMiddleware
    {
        private readonly RequestDelegate _next;

        public ShabbatMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private bool IsShabbat()
        {
            // Check if today is Saturday
            return DateTime.UtcNow.DayOfWeek == DayOfWeek.Saturday;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (IsShabbat())
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Access is forbidden on Shabbat.");
                return;
            }

            await _next(context);
        }
    }
}
