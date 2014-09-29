using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EmployeeDAL;
using EmployeeData;
using EmployeeService.Interfaces;
namespace EmployeeService
{
    /// <summary>
    /// This is the Employee Server (Service)
    /// </summary>
    public class EmployeeServer : IEmployeeService
    {
        EmployeeDataAccess _employeeDAL;
        /// <summary>
        /// Constructor that initializes the DAL.
        /// </summary>
        public EmployeeServer()
        {
            _employeeDAL = new EmployeeDataAccess();
        }

        /// <summary>
        /// Get access to all Employee objects in the DB.
        /// </summary>
        /// <returns>Generic list of Employee objects.</returns>
        public List<Employee> GetAllEmployees()
        {
            return _employeeDAL.GetAllEmployees();
        }

        /// <summary>
        /// Returns a specific employee.
        /// </summary>
        /// <param name="id">id of the Employee object to access</param>
        /// <returns>Employee object that was requested.</returns>
        public Employee GetEmployee(int id)
        {
            return _employeeDAL.GetEmployee(id);
        }

        /// <summary>
        /// Get access to all Roles in the DB.
        /// </summary>
        /// <returns>Generic list of Role objects.</returns>
        public List<Role> GetAllRoles()
        {
            return _employeeDAL.GetAllRoles();
        }

        /// <summary>
        /// Add new employee to DB.
        /// </summary>
        /// <param name="employee">Employee object to be inserted into the DB.</param>
        /// <returns>id of the new Employee object</returns>
        public int CreateEmployee(Employee employee)
        {
           return _employeeDAL.CreateEmployee(employee);
        }

        /// <summary>
        /// Update the employee record in the DB.
        /// </summary>
        /// <param name="employee">Object representing the updated values of the object</param>
        public void UpdateEmployee(Employee employee)
        {
            _employeeDAL.UpdateEmployee(employee);
        }

        /// <summary>
        /// Remove a record from the DB.
        /// </summary>
        /// <param name="employee">Record to be deleted.</param>
        public void DeleteEmployee(Employee employee)
        {
            _employeeDAL.DeleteEmployee(employee);
        }
    }
}
