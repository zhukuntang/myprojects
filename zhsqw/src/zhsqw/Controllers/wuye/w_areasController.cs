using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using zhsqw.Models;

namespace zhsqw.Controllers.wuye
{
    public class w_areasController : Controller
    {
        private DbContext _context;

        public w_areasController(DbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.w_areas.ToList());
        }

        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            w_areas w_areas = _context.w_areas.Single(m => m.ID == id);
            if (w_areas == null)
            {
                return HttpNotFound();
            }

            return View(w_areas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(w_areas w_areas)
        {
            if (ModelState.IsValid)
            {
                w_areas.ID = Guid.NewGuid().ToString();
                _context.w_areas.Add(w_areas);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(w_areas);
        }

        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            w_areas w_areas = _context.w_areas.Single(m => m.ID == id);
            if (w_areas == null)
            {
                return HttpNotFound();
            }
            return View(w_areas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(w_areas w_areas)
        {
            if (ModelState.IsValid)
            {
                _context.Update(w_areas);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(w_areas);
        }

        public IActionResult Delete(string id)
        {
            w_areas w_areas = _context.w_areas.Single(m => m.ID == id);
            _context.w_areas.Remove(w_areas);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
