using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GreenwichCommunityTheatre.Filters
{
    public class CustomAuthorizeFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (!user.Identity!.IsAuthenticated)
            {
                context.Result = new JsonResult(new { message = "Unauthorized access", status = 401 })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            else if (!user.IsInRole("Operator"))
            {
                context.Result = new JsonResult(new { message = "Forbidden", status = 403 })
                {
                    StatusCode = StatusCodes.Status403Forbidden
                };
            }
        }
    }
}
