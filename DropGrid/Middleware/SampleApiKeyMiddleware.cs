namespace DropGrid.Middleware
{
    public class SampleApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string ApiKeyHeaderName = "x-api-key";
        private const string ExpectedApiKey = "sample-key-check";

        public SampleApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var apiKey) ||
                apiKey != ExpectedApiKey)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized - Invalid API key");
                return;
            }

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}
