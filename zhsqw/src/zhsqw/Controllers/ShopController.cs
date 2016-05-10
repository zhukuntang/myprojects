using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zhsqw.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Internal;

namespace zhsqw.Controllers
{
    public class ShopController : Controller
    {
        private ApplicationDbContext _context;

        public ShopController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("www", "zkt");
            
            return View(_context.wy_news.ToList());
        }

        [HttpPost]
        public IActionResult Index(FormCollection collection)
        {
            //ViewBag.abc = collection["abc"];
            ViewBag.abc2 = HttpContext.Session.GetString("www");
            return View(_context.wy_news.ToList());
        }
    }
}
