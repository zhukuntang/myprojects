using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using zhsqw.Models;

namespace zhsqw.Controllers
{
    public class newsController : Controller
    {
        private MyDbContext _context;

        public newsController(MyDbContext context)
        {
            _context = context;    
        }

        public IActionResult Index()
        {
            return View(_context.news.ToList());
        }

        [HttpPost, ActionName("Index")]
        public IActionResult Query(string[] delChecked)
        {
            IEnumerable<news> newslist;
            string areaname = Request.Form["areaname"];
            if (areaname.Length > 0)
            {
                newslist = from m in _context.news where (m.NewsTitle.Contains(areaname)) orderby m.BookTime descending select m;
            }
            else
            {
                newslist = _context.news.ToList();
            }
            return View(newslist);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(news news)
        {
            if (ModelState.IsValid)
            {
                _context.news.Add(news);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        public IActionResult Edit(string id)
        {
            news news = _context.news.Single(m => m.ID == id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(news news)
        {
            if (ModelState.IsValid)
            {
                _context.Update(news);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }
    }
}
