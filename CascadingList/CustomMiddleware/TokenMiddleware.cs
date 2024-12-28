using System.Threading.Tasks;
using CascadingList.Repositories.IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CascadingList.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ITokenService _tokenService;
        public TokenMiddleware(RequestDelegate next, ITokenService tokenService)
        {
            _next = next;
            _tokenService = tokenService;
        }

        public async Task InvokeAsync(HttpContext Context)
        {
            var refreshToken = Context.Request.Headers["Refresh-Token"].ToString();

            // Check if refresh token is present and if it needs refreshing
            if (!string.IsNullOrEmpty(refreshToken))
            {
                var userPrincipal = _tokenService.GetPrincipalFromExpiredToken(refreshToken);
                if (userPrincipal != null)
                {
                    var newAccessToken = _tokenService.GenerateAccessToken(userPrincipal.Identity.Name);
                    Context.Response.Headers.Add("Access-Token", newAccessToken);
                }
            }

            await _next(Context);
            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TokenMiddlewareExtensions
    {
        public static IApplicationBuilder UseTokenMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenMiddleware>();
        }
    }
}
