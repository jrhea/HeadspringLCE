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
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        List<Employee> GetAllEmployees();
        [OperationContract]
        Employee GetEmployee(int id);
        [OperationContract]
        List<Role> GetAllRoles();
        [OperationContract]
        int CreateEmployee(Employee employee);
        [OperationContract]
        void UpdateEmployee(Employee employee);
        [OperationContract]
        void DeleteEmployee(Employee employee);

    }

}
