using System.Linq;
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
