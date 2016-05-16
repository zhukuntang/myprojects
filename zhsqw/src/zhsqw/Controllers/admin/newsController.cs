using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using System.Data;
using zhsqw.Models;

namespace zhsqw.Controllers
{
    public class newsController : Controller
    {
        private MyDbContext db;

        public newsController(MyDbContext context)
        {
            db = context;    
        }

        public IActionResult Index(int? page)
        {
            PagerHelper<news> pager = new PagerHelper<news>(db.news.ToList(), "/News/index", 1, page ?? 1, 3, false);
            return View(pager);
            //return View(db.news.ToList());
        }

        [HttpPost, ActionName("Index")]
        public IActionResult Query(string[] delChecked)
        {
            IEnumerable<news> newslist;
            string areaname = Request.Form["areaname"];
            if (areaname.Length > 0)
            {
                newslist = db.news.Where(x => x.NewsTitle.Contains(areaname)).OrderByDescending(x => x.BookTime);
            }
            else
            {
                newslist = db.news.ToList();
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
                db.news.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        public IActionResult Edit(string id)
        {
            news news = db.news.Single(m => m.ID == id);
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
                db.Update(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }
    }
}
