﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zhsqw.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Internal;
using Microsoft.AspNet.Mvc.Rendering;

namespace zhsqw.Controllers
{
    public class shopController : Controller
    {
        private MyDbContext db;

        public shopController(MyDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ActionName("Index")]
        public IActionResult Query()
        {

            return View();
        }
    }
}
