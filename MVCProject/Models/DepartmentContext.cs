using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class DepartmentContext : DbContext
    {
        public DepartmentContext() : base("testDB")
        {
           Database.SetInitializer(new DbInitializer());
        }
        
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
    public class DbInitializer : DropCreateDatabaseIfModelChanges<DepartmentContext>
    {
        protected override void Seed(DepartmentContext db)
        {

            Department department = new Department() {DepartmentName = "test1"};
            Department department1 = new Department() { DepartmentName = "test2",Parent = department};
            Employee employee1 = new Employee() {Department = department1};
            Employee employee2 = new Employee() {Department = department1,FirstMidName = "Ivan ivanovich",LastName = "Petrov"};
            Employee employee3 = new Employee() {Department = department,FirstMidName = "adasd dsad ",LastName = "Иванов"};
            db.Employees.AddRange(new List<Employee> {employee1, employee2, employee3});
            db.Departments.AddRange(new List<Department>() {department, department1});
            db.SaveChanges();
            base.Seed(db);
        }
    }
}