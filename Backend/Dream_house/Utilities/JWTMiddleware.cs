using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Services.UserService;
using Dream_house.Utilities.JWTUtils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Dream_house.Utilities
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JWTMiddleware(IOptions<AppSettings> appSettings, RequestDelegate next)
        {
            _appSettings = appSettings.Value;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IUserService userService, IJWTUtils jwtUtils)
        {
            var token = httpContext.Request.Headers["Autorization"].FirstOrDefault()?.Split("").Last();

            var userId = jwtUtils.ValidateJWTToken(token);

            if (userId != Guid.Empty)
            {
                httpContext.Items["User"] = userService.GetUserById(userId);
            }

            await _next(httpContext);
        }
    }
}
