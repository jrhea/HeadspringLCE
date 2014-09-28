using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeDirectory;
using EmployeeDirectory.Controllers;
using EmployeeData;

namespace EmployeeDirectory.Tests.Service
{
    [TestClass]
    public class ServiceTests
    {
        private static int _testId;
        [TestMethod]
        public void CreateTest()
        {
            EmployeeServiceRef.EmployeeServiceClient esc = new EmployeeServiceRef.EmployeeServiceClient();
            Employee employee = new Employee
            {
                FirstName = "Theodore",
                LastName = "Kerabatsos",
                HomePhone = "123456789",
                JobTitle = "Janitor",
                Location = "Dallas",
                RoleId = 1,
                Email = "outofyouremelement@foo.com"

            };
            _testId = esc.CreateEmployee(employee);
            Assert.IsTrue(_testId != -1);
        }

        [TestMethod]
        public void GetTest()
        {
            EmployeeServiceRef.EmployeeServiceClient esc = new EmployeeServiceRef.EmployeeServiceClient();
            Employee employee = esc.GetEmployee(_testId);
            Assert.IsNotNull(employee);
        }

        [TestMethod]
        public void GetAllTest()
        {
            EmployeeServiceRef.EmployeeServiceClient esc = new EmployeeServiceRef.EmployeeServiceClient();
            List<Employee> employees = esc.GetAllEmployees();
            Assert.IsNotNull(employees);
            Assert.IsTrue(employees.Count > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            EmployeeServiceRef.EmployeeServiceClient esc = new EmployeeServiceRef.EmployeeServiceClient();
            Employee employee = esc.GetEmployee(_testId);
            employee.FirstName = "Donny";
            esc.UpdateEmployee(employee);
            employee = esc.GetEmployee(_testId);
            Assert.IsNotNull(employee);
            Assert.IsTrue(employee.FirstName == "Donny");
        }

        [TestMethod]
        public void DeleteTest()
        {
            EmployeeServiceRef.EmployeeServiceClient esc = new EmployeeServiceRef.EmployeeServiceClient();
            Employee employee = esc.GetEmployee(_testId);
            esc.DeleteEmployee(employee);
            employee = esc.GetEmployee(_testId);
            Assert.IsNull(employee);
        }
    }
}
