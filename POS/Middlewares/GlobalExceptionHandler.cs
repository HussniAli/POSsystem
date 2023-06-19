namespace POS.Middlewares
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandler> _logger;
        public GlobalExceptionHandler(RequestDelegate next,ILogger<GlobalExceptionHandler>logger)
        {
        _next =next;
        _logger=logger;
        }
        public async Task Invoke(HttpContext context)
        {
          try
          {
             await _next(context);
          }
          catch(Exception ex)
          {
            context .Response.ContentType ="application/json";
            await context.Response.WriteAsync(ex.Message);
            _logger.LogError(ex.Message);
          }
        }
            
        
    }
}