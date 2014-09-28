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
    public class EmployeeServer : IEmployeeService
    {
        EmployeeDataAccess _employeeDAL;
        public EmployeeServer()
        {
            _employeeDAL = new EmployeeDataAccess();
        }
        public List<Employee> GetAllEmployees()
        {
            return _employeeDAL.GetAllEmployees();
        }
        public Employee GetEmployee(int id)
        {
            return _employeeDAL.GetEmployee(id);
        }
        public List<Role> GetAllRoles()
        {
            return _employeeDAL.GetAllRoles();
        }
        public int CreateEmployee(Employee employee)
        {
           return _employeeDAL.CreateEmployee(employee);
        }
        public void UpdateEmployee(Employee employee)
        {
            _employeeDAL.UpdateEmployee(employee);
        }
        public void DeleteEmployee(Employee employee)
        {
            _employeeDAL.DeleteEmployee(employee);
        }
    }
}
