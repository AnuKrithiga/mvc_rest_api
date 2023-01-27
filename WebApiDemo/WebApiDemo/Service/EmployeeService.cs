using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebApiDemo.Models;

namespace WebApiDemo.Service
{
    public class EmployeeService
    {
        private EmpDBContext db = new EmpDBContext();

        public IEnumerable<Employee> GetAllEmployees()
        {
            var employees = db.Employees;
            return db.Employees.ToList();
        }

        public Employee GetEmployee(int id)
        {
            var employee = db.Employees.FirstOrDefault((p) => p.ID == id);
            return employee;
        }
        
        public void SaveEmployeee (Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
        }

        public Employee UpdateEmployee(Employee e)
        {
            var employee = db.Employees.FirstOrDefault((p) => p.ID == e.ID);
            if (employee != null)
            {
                employee.Name = e.Name;
                employee.Age = e.Age;
                employee.JoiningDate = e.JoiningDate;
                db.SaveChanges();
                return employee;
            }
            return null;
        }
    }
}