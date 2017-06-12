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
    }
}