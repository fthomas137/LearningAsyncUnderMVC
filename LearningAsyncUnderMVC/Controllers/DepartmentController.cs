using LearningAsyncUnderMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LearningAsyncUnderMVC.Controllers
{
    public class DepartmentController : Controller
    {
        private MyDB _db = new MyDB();

        public async Task<ActionResult> Index()
        {
            return View(await _db.Departments.ToListAsync());
        }

        public ActionResult Create()
        {
            return View(new Department());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Department model)
        {
            if (ModelState.IsValid)
            {
                _db.Departments.Add(model);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<ActionResult> Details(int id = 0)
        {
            var department = await _db.Departments.FirstOrDefaultAsync(d => d.Id == id);
            if (department == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return View(department);
        }

        public async Task<ActionResult> Edit(int id = 0)
        {
            var department = await _db.Departments.FirstOrDefaultAsync(d => d.Id == id);
            if (department == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(department).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(department);
        }
    }
}