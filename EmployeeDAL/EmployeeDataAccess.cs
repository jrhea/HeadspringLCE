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
        private EmployeeModel _db = new EmployeeModel();
        public List<IEmployee> GetAllEmployees()
        {
            var result = from e in _db.Employees
            select e;
            return result.ToList().Cast<IEmployee>().ToList();
        }

        public IEmployee GetEmployee(int id)
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

        public void CreateEmployee(IEmployee employee)
        {
            _db.Employees.Add((Employee)employee);
            _db.SaveChanges();
        }

        public void UpdateEmployee(IEmployee employee)
        {
            _db.Entry(employee).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public void DeleteEmployee(IEmployee employee)
        {
            _db.Employees.Attach((Employee)employee);
            _db.Employees.Remove((Employee)employee);
            _db.SaveChanges();
        }
    }
}