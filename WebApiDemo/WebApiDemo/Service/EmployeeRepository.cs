using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebApiDemo.Models;

namespace WebApiDemo.Service
{
    public class EmployeeRepository
    {
        Employee[] employees = new Employee[]
            {
            new Employee
            {
                ID = 1,
                Name = "Mark",
                JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                Age = 30
            },
            new Employee
            {
                ID = 2,
                Name = "Allan",
                JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                Age = 35
            },
            new Employee
            {
                ID = 3,
                Name = "Johny",
                JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                Age = 21
            }
        };

        public Employee[] GetAllEmployees()
        {
            return employees;
        }

        public Employee GetEmployee(int id)
        {
            var employee = employees.FirstOrDefault((p) => p.ID == id);
            return employee;
        }
    }
}