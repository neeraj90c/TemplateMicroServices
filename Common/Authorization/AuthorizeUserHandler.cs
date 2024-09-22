using Common.DTO;
using Common.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common.Authorization
{
    // This class contains logic for determining whether MinimumAgeRequirements in authorization
    // policies are satisfied or not
    public class AuthorizeUserHandler : AuthorizationHandler<AuthorizeUserRequirement>
    {
        public readonly ILogger<AuthorizeUserHandler> _logger;
        public readonly IJwtToken _jwtToken;
        IHttpContextAccessor _httpContextAccessor = null;

        public AuthorizeUserHandler(ILogger<AuthorizeUserHandler> logger, IHttpContextAccessor httpContextAccessor, IJwtToken jwtToken)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _jwtToken = jwtToken;
        }

        // Check whether a given MinimumAgeRequirement is satisfied or not for a particular context
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizeUserRequirement requirement)
        {
            HttpContext httpContext = _httpContextAccessor.HttpContext;

            //IJwtToken jwtToken;
            string token = httpContext.Request.Headers["Authorization"];
            UserSessionDTO userSessionDTO = _jwtToken.ValidateToken(token);
            if (userSessionDTO != null)
            {
                context.Succeed(requirement);
            }
            else
            {
                byte[] bytes;
                bytes = Encoding.UTF8.GetBytes("Token Expired");
                httpContext.Response.StatusCode = 405;
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
            }

            return Task.CompletedTask;
        }
    }
}
