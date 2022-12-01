using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WebApiDemoTest
{
    [TestClass]
    public class WebApiDemoTest
    {
        public class WebApiDemoTest
        {
            [TestMethod]
            public async Task GetAllEmployees_ShouldReturnAll()
            {
                var controller = new EmployeesController();
                var result = controller.GetAllEmployees() as NegotiatedContentResult<Employee>;

                Assert.Equals(HttpStatusCode.OK, result.StatusCode);
            }
        }
    }
}
