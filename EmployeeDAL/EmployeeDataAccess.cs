using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EmployeeData;
namespace EmployeeDAL
{
    /// <summary>
    /// Data Access Layer.
    /// This class transforms objects into records and vice versa.
    /// </summary>
    public class EmployeeDataAccess
    {
        private EmployeeModel _db;
        /// <summary>
        /// Constructor that initialize the dbcontext (EmployeeModel).
        /// </summary>
        public EmployeeDataAccess()
        {
            _db = new EmployeeModel("EmployeeModel");
        }

        /// <summary>
        /// Get access to all Employee objects in the DB.
        /// </summary>
        /// <returns>Generic list of Employee objects.</returns>
        public List<Employee> GetAllEmployees()
        {
            var result = from e in _db.Employees
            select e;
            return result.ToList();
        }

        /// <summary>
        /// Returns a specific employee.
        /// </summary>
        /// <param name="id">id of the Employee object to access</param>
        /// <returns>Employee object that was requested.</returns>
        public Employee GetEmployee(int id)
        {
            var result = _db.Employees.Find(id);
            return result;
        }

        /// <summary>
        /// Get access to all Roles in the DB.
        /// </summary>
        /// <returns>Generic list of Role objects.</returns>
        public List<Role> GetAllRoles()
        {
            var result = from e in _db.Roles
                         select e;
            return result.ToList();
        }

        /// <summary>
        /// Add new employee to DB.
        /// </summary>
        /// <param name="employee">Employee object to be inserted into the DB.</param>
        /// <returns>id of the new Employee object</returns>
        public int CreateEmployee(Employee employee)
        {
            int result = -1;
            _db.Employees.Add((Employee)employee);
            _db.SaveChanges();
            Employee test =_db.Entry(employee).Entity;
            if (test != null)
            {
                result = test.Id;
            }
            return result;
        }

        /// <summary>
        /// Update the employee record in the DB.
        /// </summary>
        /// <param name="employee">Object representing the updated values of the object</param>
        public void UpdateEmployee(Employee employee)
        {
            _db.Entry(employee).State = EntityState.Modified;
            _db.SaveChanges();
        }

        /// <summary>
        /// Remove a record from the DB.
        /// </summary>
        /// <param name="employee">Record to be deleted.</param>
        public void DeleteEmployee(Employee employee)
        {
            _db.Employees.Attach((Employee)employee);
            _db.Employees.Remove((Employee)employee);
            _db.SaveChanges();
        }
    }
}