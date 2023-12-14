using System.Net;

namespace test.api.middleware
{
    public class exception
    {
        private readonly ILogger<exception> logger;
        private readonly RequestDelegate requestDelegate;

        public exception(ILogger<exception> logger,RequestDelegate requestDelegate)
        {
            this.logger = logger;
            this.requestDelegate = requestDelegate;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await requestDelegate(httpContext);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                logger.LogError($"{errorId} : {ex.Message}");

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                    EMessage = "Stg went wrong",
                };
                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
