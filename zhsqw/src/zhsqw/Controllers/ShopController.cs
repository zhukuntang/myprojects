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
            IndexViewModel q = new IndexViewModel();
            q.SysNews = _context.SysNews.ToList();
            return View(q);
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel q)
        {
            ViewBag.abc = q.abc;
            ViewBag.cde = q.cde;
            q.SysNews = _context.SysNews.Where(m => m.ID == q.abc).ToList();
            return View(q);
        }
    }
}
