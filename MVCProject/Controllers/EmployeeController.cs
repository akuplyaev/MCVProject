using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class EmployeeController : Controller
    {
        DepartmentContext db = new DepartmentContext();
        public ActionResult DeleteEmployee(int? employeeId)
        {
            if (employeeId == null)
            {
                return HttpNotFound();
            }
            Employee employee = db.Employees.Find(employeeId);
            if (employee == null)
            {
                return HttpNotFound();
            }
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index", "Department");
        }

        public ActionResult AddEmployee(int? departmentId)
        {
            if (departmentId == null)
            {
                return HttpNotFound();
            }            
            Department department = db.Departments.Find(departmentId);
            ViewBag.Department = department;
            return View();
        }
        public ActionResult CreateEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index","Department");
        }
        public ActionResult ChangeEmployee(int employeeId)
        {
            var employee = db.Employees.Find(employeeId);
            if (employee == null)
            {
                return HttpNotFound();
            }
            SelectList departmentList = new SelectList(db.Departments,"DepartmentId","DepartmentName");
            ViewBag.Departments = departmentList;
            return View(employee);
        }
        public ActionResult UpdateEmployee(Employee employee)
        {           
            if (employee == null)
            {
                return HttpNotFound();
            }          
            db.Entry(employee).State=EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Department");
        }
    }
}