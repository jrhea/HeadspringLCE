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
    [KnownType(typeof(Employee))]
    public class EmployeeServer : IEmployeeService
    {
        EmployeeDataAccess _employeeDAL = new EmployeeDataAccess();
        public EmployeeServer()
        {
           _employeeDAL = new EmployeeDataAccess();
        }
        public List<IEmployee> GetAllEmployees()
        {
            
            return _employeeDAL.GetAllEmployees();
        }
        public IEmployee GetEmployee(int id)
        {
            return _employeeDAL.GetEmployee(id);
        }
        public List<Role> GetAllRoles()
        {
            return _employeeDAL.GetAllRoles();
        }
        public void CreateEmployee(IEmployee employee)
        {
            _employeeDAL.CreateEmployee(employee);
        }
        public void UpdateEmployee(IEmployee employee)
        {
            _employeeDAL.UpdateEmployee(employee);
        }
        public void DeleteEmployee(IEmployee employee)
        {
            _employeeDAL.DeleteEmployee(employee);
        }
    }
}
