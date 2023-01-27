using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiDemo.Controllers;
using WebApiDemo.Models;

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
            //Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
    }

}
