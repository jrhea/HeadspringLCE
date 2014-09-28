using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EmployeeData;
namespace EmployeeDAL
{
    public class EmployeeDataAccess
    {
        private EmployeeModel _db;
        public EmployeeDataAccess()
        {
            _db = new EmployeeModel("EmployeeModel");
        }
        public List<Employee> GetAllEmployees()
        {
            var result = from e in _db.Employees
            select e;
            return result.ToList();
        }

        public Employee GetEmployee(int id)
        {
            var result = _db.Employees.Find(id);
            return result;
        }

        public List<Role> GetAllRoles()
        {
            var result = from e in _db.Roles
                         select e;
            return result.ToList();
        }

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

        public void UpdateEmployee(Employee employee)
        {
            _db.Entry(employee).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public void DeleteEmployee(Employee employee)
        {
            _db.Employees.Attach((Employee)employee);
            _db.Employees.Remove((Employee)employee);
            _db.SaveChanges();
        }
    }
}