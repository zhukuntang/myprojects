using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using System.Collections;

namespace zhsqw.Controllers.admin
{
    public class adminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
