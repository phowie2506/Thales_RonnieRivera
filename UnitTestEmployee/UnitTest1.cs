using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Thales_RonnieRivera.Controllers;

namespace UnitTestEmployee
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsEndPointUp()
        {
            // to valide if the endpoint is up
            string url = "http://dummy.restapiexample.com/api/v1/employees";

            employeeController Employee = new employeeController();

            var result = Employee.GetEmployees(url);

            Assert.AreEqual("success", result.status);
        }
    }
}
