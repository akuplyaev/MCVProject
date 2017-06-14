using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentContext db = new DepartmentContext();


        public ActionResult Index()
        {

            var listDepartments = db.Departments;
            return PartialView(listDepartments);

        }
        public ActionResult AddDepartment(int? departmentId)
        {

            if (departmentId == null)
            {
                return HttpNotFound();
            }
            Department parentDepartment = db.Departments.Find(departmentId);
            ViewBag.ParentDepartment = parentDepartment;
            return View();
        }
        public ActionResult CreateDepartment(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
            return RedirectToAction("Index", "Department");
        }
        public ActionResult DeleteDepartment(int? departmentId)
        {
            if (departmentId == null)
            {
                return HttpNotFound();
            }            
            var department = db.Departments.Find(departmentId);
            DeleteTree(department);
            db.SaveChanges();
            return RedirectToAction("Index", "Department");

        }

        public void DeleteTree(Department department)
        {
            
            var depChild = db.Departments.Where(d => d.ParentDepartmentId == department.DepartmentId)
                .OrderBy(d => d.DepartmentId);
            if (depChild.Any())
            {
                foreach (var child in depChild)
                {
                    DeleteTree(child);
                    db.Departments.Remove(child);
                }
                db.Departments.Remove(department);
            }
            else
            {
                db.Departments.Remove(department);
            }
        }

    }

}