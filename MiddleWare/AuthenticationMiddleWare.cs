namespace BookShelf.MiddleWare
{
    public class AuthenticationMiddleWare
    {
        private const string API_KEY_HEADER_NAME = "X-Api-Key";
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public AuthenticationMiddleWare(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(API_KEY_HEADER_NAME, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key mancante");
                return;
            }

            var apiKey = _configuration.GetValue<string>("ApiKey");
            if (!apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key non valida");
                return;
            }

            await _next(context);
        }
    }
}
