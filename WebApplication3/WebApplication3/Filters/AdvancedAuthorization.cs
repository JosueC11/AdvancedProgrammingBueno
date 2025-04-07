using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace WebApplication3.Filters
{
    public class AdvancedAuthorization : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                // Example: Check roles if specified
                if (!string.IsNullOrEmpty(Roles))
                {
                    var roles = Roles.Split(',');
                    if (!roles.Any(httpContext.User.IsInRole))
                    {
                        return false; // User does not have the required role
                    }
                }
                return true; // Authorized
            }
            return false; // Not authenticated
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                // Redirect to login page if not authenticated
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                { "controller", "Account" },
                { "action", "Login" }
                    }
                );
            }
            else
            {
                // Show "Unauthorized" page if authenticated but not authorized
                filterContext.Result = new ViewResult { ViewName = "Unauthorized" };
            }
        }
    }
}
