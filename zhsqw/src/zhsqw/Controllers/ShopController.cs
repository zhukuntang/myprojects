using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zhsqw.Models;
using zhsqw.ViewModels.Shop;
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
            return View(_context.SysNews.ToList());
        }

        [HttpPost, ActionName("Index")]
        public IActionResult Query(FormCollection collection) 
        {
            ViewBag.abc = collection["abc"];
            ViewBag.cde = collection["cde"];
            return View(_context.SysNews.ToList());
        }

        public IActionResult m1()
        {
            QueryViewModel q = new QueryViewModel();
            return View(q);
        }

        [HttpPost]
        public IActionResult m1(QueryViewModel q)
        {

            return RedirectToAction("Shop", "Index");
        }
    }
}
