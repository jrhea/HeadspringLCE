using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeDirectory;
using EmployeeDirectory.Controllers;
using EmployeeData;

namespace UnitTests.Controllers
{
    /// <summary>
    /// Unit tests for views.
    /// </summary>
    [TestClass]
    public class ViewTests
    {
        /// <summary>
        ///  Passes if the index view is returned successfully.
        /// </summary>
        [TestMethod]
        public void IndexView()
        {
            // Arrange
            EmployeesController controller = new EmployeesController("1001");

            // Act
            ViewResult result = controller.Index("Last Name", "", "L",1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Passes if the details view is returned successfully.
        /// </summary>
        [TestMethod]
        public void DetailsView()
        {
            // Arrange
            EmployeesController controller = new EmployeesController("1001");

            // Act
            ViewResult result = controller.Details(1001) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Passes if the create view is returned successfully.
        /// </summary>
        [TestMethod]
        public void CreateView()
        {
            // Arrange
            EmployeesController controller = new EmployeesController("1001");

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Passes if the edit view is returned successfully.
        /// </summary>
        [TestMethod]
        public void EditView()
        {
            // Arrange
            EmployeesController controller = new EmployeesController("1001");

            // Act
            ViewResult result = controller.Edit(1001) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Passes if the delete view is returned successfully.
        /// </summary>
        [TestMethod]
        public void DeleteView()
        {
            // Arrange
            EmployeesController controller = new EmployeesController("1001");

            // Act
            ViewResult result = controller.Delete(1001) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
