using System;
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
    public class wuyeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult test()
        {
            return View();
        }
    }
}
