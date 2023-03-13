using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiDemo.Controllers;
using WebApiDemo.Models;
using System;

namespace WebApiDemoTest
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public async Task GetAllEmployees_ShouldReturnAll()
        {
            var controller = new EmployeesController();
            var result = controller.GetAllEmployees() as List<Employee>;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public async Task GetAllEmployees_CheckForLength()
        {
            var controller = new EmployeesController();
            var result = controller.GetAllEmployees() as List<Employee>;
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public async Task GetEmployee_ShouldReturnResult()
        {
            var controller = new EmployeesController();
            var result = controller.GetEmployee(1) as OkNegotiatedContentResult<Employee>;
            Assert.AreEqual(result.Content.ID, 1);
        }
        [TestMethod]
        public async Task GetEmployee_ShouldNotReturnResult()
        {
            var controller = new EmployeesController();
            var result = controller.GetEmployee(9999) as OkNegotiatedContentResult<Employee>;
            Assert.IsNull(result);
        }
        [TestMethod]
        public async Task CreateEmployee_ShouldPass()
        {
            var controller = new EmployeesController();
            Employee e = new Employee();
            Random rnd = new Random();
            int num = rnd.Next(9999);
            e.Name = "UT user " + num;
            e.JoiningDate = DateTime.Now;
            e.Age = num;

            var result = controller.Create(e) as OkNegotiatedContentResult<Employee>;
            Assert.IsNotNull(result.Content);
        }
        [TestMethod]
        public async Task EditEmployee_ShouldPass()
        {
            var controller = new EmployeesController();
            var e = controller.GetEmployee(1) as OkNegotiatedContentResult<Employee>;
            e.Content.Age += 2;

            var edit = controller.Edit(e.Content);
            var result = controller.GetEmployee(1) as OkNegotiatedContentResult<Employee>;
            Assert.AreEqual(result.Content.Age, e.Content.Age);

        }

    }

}
