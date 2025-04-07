using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication3.Filters
{
    public class RetriesValidationFilter : ActionFilterAttribute // resultfilter, authorization filter
    {
        private static readonly ConcurrentDictionary<string, Retry> _retryMap = new ConcurrentDictionary<string, Retry>();
        private const int retries = 3;
        private const int blockFor = 3;

        public RetriesValidationFilter() { }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string clientIp = filterContext.HttpContext.Request.UserHostAddress;
            if (string.IsNullOrEmpty(clientIp))
                return;

            var now = DateTime.UtcNow;
            if (!_retryMap.TryGetValue(clientIp, out Retry retry))
            {
                _retryMap[clientIp] = new Retry { Count = 1, BlockEndsAt = now.AddMinutes(blockFor) };
                return;
            }

            if (now >= retry.BlockEndsAt)
            {
                _retryMap[clientIp] = new Retry { Count = 1, BlockEndsAt = now.AddMinutes(blockFor) };
                return;
            }

            if (retry.Count >= retries && now < retry.BlockEndsAt)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                        { "controller", "Account" },
                        { "action", "Error" },
                        { "message", $"Too many login attempts. Retry again after: {retry.BlockEndsAt}"}
                    }
                );
                return;
            }

            retry.Count++; // Increment retry count
            _retryMap[clientIp] = retry;

            base.OnActionExecuting(filterContext);
        }

        private class Retry
        {
            public static string ClientIP => HttpContext.Current?.Request?.UserHostAddress;
            public int Count { get; set; }
            public DateTime BlockEndsAt { get; set; }
        }
    }
}