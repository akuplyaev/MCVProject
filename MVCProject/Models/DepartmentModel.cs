using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }       
        public int? ParentDepartmentId { get; set; }
        [ForeignKey("ParentDepartmentId")]
        public Department ParentDepartment { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
    
   
}