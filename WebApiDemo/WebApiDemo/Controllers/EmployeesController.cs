using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiDemo.Service;
using WebApiDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace WebApiDemo.Controllers
{
    public class EmployeesController : ApiController
    {
        private EmployeeRepository employeeRepository;
        private EmpDBContext db = new EmpDBContext();

        public EmployeesController()
        {
            this.employeeRepository = new EmployeeRepository();
        }
        /*public IEnumerable<Employee> GetAllEmployees()
        {
            return employeeRepository.GetAllEmployees();
        }

        public IHttpActionResult GetEmployee(int id)
        {
            var employee = employeeRepository.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }*/

        [System.Web.Http.HttpPost]
        public IHttpActionResult Create(Employee emp)
        {
            try
            {
                db.Employees.Add(emp);
                db.SaveChanges();
                return Ok(emp);
            }
            catch
            {
                return InternalServerError();
            }
        }


        // PUT: Employee/Edit/5
        [System.Web.Http.HttpPut]
        public IHttpActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var employee = db.Employees.Single(m => m.ID == id);
                if (employee != null)
                {
                    db.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
            catch
            {
                return InternalServerError();
            }
        }

    }
}