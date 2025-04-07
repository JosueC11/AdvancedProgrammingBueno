using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication3.Filters
{
    public class TimeAllowanceAttribute : ActionFilterAttribute
    {
        private readonly int _start;
        private readonly int _end;

        public TimeAllowanceAttribute(int start = 19, int end = 21) { 
            _start = start;
            _end = end;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var now = DateTime.Now.Hour;
            if (_start <= now && now <= _end)
            {
                base.OnActionExecuted(filterContext);
                return;
            }

            filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                { "controller", "Account" },
                { "action", "Error" }
                    }
                );
        }
    }
}