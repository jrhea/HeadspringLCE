using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeData;
namespace EmployeeDirectory
{
    public class CompositeModel
    {
        public List<IEmployee> Employees { get; set; }
        public IEmployee CurrentEmployee { get; set; }
        public List<Role> Roles { get; set; }
        public Role CurrentRole
        {
            get
            {
                Role result = null;
                if(CurrentEmployee != null)
                {

                    result = Roles.First(x => x.Id == CurrentEmployee.RoleId);
                }
                else
                {
                    result = Roles.ElementAt(0);
                }
                return result;
            }
            set
            {
                CurrentEmployee.RoleId = value.Id;
            }
        }

    }
}