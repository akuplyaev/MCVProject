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
            Department control = new Department() {DepartmentName = "Управление"};
            Department department1 = new Department() { DepartmentName = "Отдел1", ParentDepartment = control};
            Department department2 = new Department() { DepartmentName = "Отдел2", ParentDepartment = control };
            Department department3 = new Department() { DepartmentName = "Отдел3", ParentDepartment = control };
            Department group11 = new Department() {DepartmentName = "Группа11",  ParentDepartment = department1};
            Department group12 = new Department() { DepartmentName = "Группа12", ParentDepartment = department1 };
            Department group13 = new Department() { DepartmentName = "Группа13", ParentDepartment = department1 };
            Department group21 = new Department() { DepartmentName = "Группа21", ParentDepartment = department2 };
            Department group22 = new Department() { DepartmentName = "Группа22", ParentDepartment = department2 };
            Employee employee1 = new Employee() {Department = group11,FirstMidName = "Petr pret",LastName = "Ptrov"};
            Employee employee2 = new Employee() {Department = control,FirstMidName = "Ivan ivanovich",LastName = "Petrov"};
            Employee employee3 = new Employee() {Department = department1,FirstMidName = "adasd dsad ",LastName = "Иванов"};
            db.Employees.AddRange(new List<Employee> {employee1, employee2, employee3});
            db.Departments.AddRange(new List<Department>()
            {
                control,
                department1,
                department2,
                department3,
                group11,
                group12,
                group13,
                group21,
                group22               
            });
            db.SaveChanges();
            base.Seed(db);
        }
    }
}