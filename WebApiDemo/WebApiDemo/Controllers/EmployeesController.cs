using System.Collections.Generic;
using System.Web.Http;
using WebApiDemo.Service;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    public class EmployeesController : ApiController
    {
        private EmployeeService employeeService;

        public EmployeesController()
        {
            this.employeeService = new EmployeeService();
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeeService.GetAllEmployees();
        }

        public IHttpActionResult GetEmployee(int id)
        {
            var employee = employeeService.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult Create(Employee emp)
        {
            try
            {
                employeeService.SaveEmployeee(emp);
                return Ok(emp);
            }
            catch
            {
                return InternalServerError();
            }
        }


        // PUT: Employee/Edit/5
        [System.Web.Http.HttpPut]
        public IHttpActionResult Edit(Employee emp)
        {
            try
            {
                var employee = employeeService.UpdateEmployee(emp);
                if (employee != null)
                {
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