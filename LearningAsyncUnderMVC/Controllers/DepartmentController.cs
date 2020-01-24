using LearningAsyncUnderMVC.Models;
using LearningAsyncUnderMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LearningAsyncUnderMVC.Controllers
{
    public class DepartmentController : Controller
    {
        private DepartmentServices _departmentServices = new DepartmentServices();

        public async Task<ActionResult> Index()
        {
            return View(await _departmentServices.GetAllAsync());
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
                var result = await _departmentServices.CreateAsync(model);
                if (!result.IsSuccessful)
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<ActionResult> Details(int id = 0)
        {
            var department = await _departmentServices.GetAsync(id);
            if (department == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return View(department);
        }

        public async Task<ActionResult> Edit(int id = 0)
        {
            var department = await _departmentServices.GetAsync(id);
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
                var response = await _departmentServices.UpdateAsync(department);
                if (response.IsSuccessful == false)
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                return RedirectToAction("Index");
            }
            return View(department);
        }

        public async Task<ActionResult> Delete(int id = 0)
        {
            var department = await _departmentServices.GetAsync(id);
            if (department == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return View(department);
        }

        //[HttpPost,ActionName("Delete")] //one alternative on the delete confirmation
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(Department department)
        //{
        //    _db.Entry(department).State = EntityState.Deleted;
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        [HttpPost, ActionName("Delete")] //second way to perform the same delete confirmation action
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var response = await _departmentServices.DeleteAsync(id);
            if (!response.IsSuccessful)
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _departmentServices.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}