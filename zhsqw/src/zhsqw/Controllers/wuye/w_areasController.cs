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
        private MyDbContext db;

        public w_areasController(MyDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.w_areas.ToList());
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
                db.w_areas.Add(w_areas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(w_areas);
        }

        public IActionResult Edit(string id)
        {
            w_areas w_areas = db.w_areas.Single(m => m.ID == id);
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
                db.Update(w_areas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(w_areas);
        }

        public IActionResult Delete(string id)
        {
            w_areas w_areas = db.w_areas.Single(m => m.ID == id);
            db.w_areas.Remove(w_areas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
