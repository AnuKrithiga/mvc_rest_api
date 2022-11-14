using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDemo.Service;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    public class EmployeesController : ApiController
    {
        private EmployeeRepository employeeRepository;
        public EmployeesController()
        {
            this.employeeRepository = new EmployeeRepository();
        }
        public IEnumerable<Employee> GetAllEmployees()
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
        }
    }
}