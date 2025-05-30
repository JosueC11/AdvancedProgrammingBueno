﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Filters;

namespace WebApplication3.Controllers
{
    [Authorize]
    [AdvancedAuthorization]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [TimeAllowance]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}