﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeBookMVC.Controllers
{
    public class NaviController : Controller
    {
        // GET: Navi
        public ActionResult Index()
        {
            return View();
        }
    }
}