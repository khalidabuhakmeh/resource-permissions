using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace resource_permissions.Infrastructure.Authorization
{
    public class PermissionAuthorizationHandler :
        AuthorizationHandler<PermissionRequirement>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.Resource is AuthorizationFilterContext)
            {
                var ctx = (AuthorizationFilterContext)context.Resource;
                var intention = ctx.HttpContext.Request.Method.AsIntention();
                var resource = ctx.RouteData.Values["controller"].ToString();

                var permission = $"{resource}:{intention}";

                if (
                    ctx.HttpContext.User.IsInRole(permission) ||
                    ctx.HttpContext.User.HasClaim("permission", permission)
                )
                {
                    context.Succeed(requirement);
                }
            }

            await Task.Yield();
        }
    }

    public static class HttpMethodExtensions
    {
        private static readonly IDictionary<string,string> Intentions =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "get", "Read"},
                { "post", "write"},
                { "put", "write"},
                { "delete", "delete"},
                { "option", "read"}
            };

        public static string AsIntention(this string method)
        {
            return Intentions.TryGetValue(method, out var intention)
                ? intention
                : "unknown";
        }
    }
}