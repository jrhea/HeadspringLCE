using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeDirectory;
using EmployeeDirectory.Controllers;
using EmployeeData;
namespace UnitTests.Security
{
    /// <summary>
    /// Unit tests for view security.  Since the security is based on .Net
    /// Since the view security relies entirely on .Net AuthorizationAttribute component,
    /// the unit tests are written to ensure that the proper views are decorated.
    /// </summary>
    [TestClass]
    public class SecurityTests
    {
        /// <summary>
        /// Test passes if the create view is decorated with the AuthorizeAttribute.
        /// </summary>
        [TestMethod]
        public void CreateViewAccess()
        {
            var controller = new EmployeesController();
            var type = controller.GetType();
            var methodInfo = type.GetMethod("Create",new Type[] {});
            var attributes = methodInfo.GetCustomAttributes(typeof(AuthorizeAttribute), true);
            Assert.IsTrue(attributes.Any());
        }

        /// <summary>
        /// Test passes if the edit view is decorated with the AuthorizeAttribute.
        /// </summary>
        [TestMethod]
        public void EditViewAccess()
        {
            var controller = new EmployeesController();
            var type = controller.GetType();
            var methodInfo = type.GetMethod("Edit", new Type[] {typeof(Employee)});
            var attributes = methodInfo.GetCustomAttributes(typeof(AuthorizeAttribute), true);
            Assert.IsTrue(attributes.Any());
        }

        /// <summary>
        /// Test passes if the delete view is decorated with the AuthorizeAttribute.
        /// </summary>
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
