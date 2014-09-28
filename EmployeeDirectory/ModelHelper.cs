using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeData;
namespace EmployeeDirectory
{
    public class ModelHelper
    {
        public IEmployee SessionIdentity { get; set; }

        public IEmployee Employee { get; set; }

        public Role SessionIdentityRole
        {
            get
            {
                Role result = null;
                if (SessionIdentity != null)
                {

                    result = Roles.First(x => x.Id == SessionIdentity.RoleId);
                }
                else
                {
                    result = Roles.ElementAt(0);
                }
                return result;
            }
            set
            {
                SessionIdentity.RoleId = value.Id;
            }
        }

        public Role EmployeeRole
        {
            get
            {
                Role result = null;
                if(Employee != null)
                {

                    result = Roles.First(x => x.Id == Employee.RoleId);
                }
                else
                {
                    result = Roles.ElementAt(0);
                }
                return result;
            }
            set
            {
                Employee.RoleId = value.Id;
            }
        }

        public List<Role> Roles { get; set; }

        public void CreateGuestIdentity()
        {
            SessionIdentity = new Employee()
                {
                    FirstName = "Guest",
                    LastName = "User",
                    RoleId = 1
                };
        }

    }
}