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
    [ServiceKnownType(typeof(Employee))]
    public interface IEmployeeService
    {
        [OperationContract]
        List<IEmployee> GetAllEmployees();
        [OperationContract]
        IEmployee GetEmployee(int id);
        [OperationContract]
        List<Role> GetAllRoles();
        [OperationContract]
        void CreateEmployee(IEmployee employee);
        [OperationContract]
        void UpdateEmployee(IEmployee employee);
        [OperationContract]
        void DeleteEmployee(IEmployee employee);

    }

}
