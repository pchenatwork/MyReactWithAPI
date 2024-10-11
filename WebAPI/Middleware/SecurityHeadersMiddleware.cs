using Microsoft.Extensions.Primitives;

namespace WebAPI.Middleware
{
    public sealed class SecurityHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public SecurityHeadersMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Reference : https://www.meziantou.net/security-headers-in-asp-net-core.htm
            context.Response.Headers.Add("X-Content-Type-Options", new StringValues("nosniff"));
            context.Response.Headers.Add("X-Frame-Options", new StringValues("DENY"));
            context.Response.Headers.Add("X-Permitted-Cross-Domain-Policies", new StringValues("none"));
            context.Response.Headers.Add("X-XSS-Protection", new StringValues("1; mode=block"));
            await this._next(context);
        }
    }
}
