using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class Employee
    {
        public int EmployeeId { get;set;}
        public string FirstMidName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string DepartmentId { get; set; }

     }
}
