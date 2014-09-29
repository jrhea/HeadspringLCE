using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeDirectory;
using EmployeeDirectory.Controllers;
using EmployeeData;
namespace EmployeeDirectory.Tests.Security
{
    [TestClass]
    public class SecurityTests
    {

        [TestMethod]
        public void CreateViewAccess()
        {
            var controller = new EmployeesController();
            var type = controller.GetType();
            var methodInfo = type.GetMethod("Create",new Type[] {});
            var attributes = methodInfo.GetCustomAttributes(typeof(AuthorizeAttribute), true);
            Assert.IsTrue(attributes.Any());
        }

        [TestMethod]
        public void EditViewAccess()
        {
            var controller = new EmployeesController();
            var type = controller.GetType();
            var methodInfo = type.GetMethod("Edit", new Type[] {typeof(Employee)});
            var attributes = methodInfo.GetCustomAttributes(typeof(AuthorizeAttribute), true);
            Assert.IsTrue(attributes.Any());
        }

        [TestMethod]
        public void DeleteViewAccess()
        {
            var controller = new EmployeesController();
            var type = controller.GetType();
            var methodInfo = type.GetMethod("Delete", new Type[] { typeof(int)});
            var attributes = methodInfo.GetCustomAttributes(typeof(AuthorizeAttribute), true);
            Assert.IsTrue(attributes.Any());
        }
    }
}
