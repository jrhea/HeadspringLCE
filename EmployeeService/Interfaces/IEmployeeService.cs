using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EmployeeDAL;
using EmployeeData;
namespace EmployeeService.Interfaces
{
    /// <summary>
    /// This is the communication interface (contract) between client and server communication
    /// </summary>
    [ServiceContract]
    public interface IEmployeeService
    {
        /// <summary>
        /// Get access to all Employee objects in the DB.
        /// </summary>
        /// <returns>Generic list of Employee objects.</returns>
        [OperationContract]
        List<Employee> GetAllEmployees();

        /// <summary>
        /// Returns a specific employee.
        /// </summary>
        /// <param name="id">id of the Employee object to access</param>
        /// <returns>Employee object that was requested.</returns>
        [OperationContract]
        Employee GetEmployee(int id);

        /// <summary>
        /// Get access to all Roles in the DB.
        /// </summary>
        /// <returns>Generic list of Role objects.</returns>
        [OperationContract]
        List<Role> GetAllRoles();

        /// <summary>
        /// Add new employee to DB.
        /// </summary>
        /// <param name="employee">Employee object to be inserted into the DB.</param>
        /// <returns>id of the new Employee object</returns>
        [OperationContract]
        int CreateEmployee(Employee employee);

        /// <summary>
        /// Update the employee record in the DB.
        /// </summary>
        /// <param name="employee">Object representing the updated values of the object</param>
        [OperationContract]
        void UpdateEmployee(Employee employee);

        /// <summary>
        /// Remove a record from the DB.
        /// </summary>
        /// <param name="employee">Record to be deleted.</param>
        [OperationContract]
        void DeleteEmployee(Employee employee);

    }

}
