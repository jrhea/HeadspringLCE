using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeData;
namespace EmployeeDirectory
{
    /// <summary>
    /// Simple helper class to manage session identity
    /// </summary>
    public class ModelHelper
    {
        /// <summary>
        /// The is the current user of the session
        /// </summary>
        public Employee SessionIdentity { get; set; }

        /// <summary>
        /// This is the currently inspected record
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// Returns the role of the current session user
        /// </summary>
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

        /// <summary>
        /// This is the associated role of the current record
        /// </summary>
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

        /// <summary>
        /// A list of all the roles
        /// </summary>
        public List<Role> Roles { get; set; }

        /// <summary>
        /// Helper method to create a guest identity when the user is not in the DB
        /// </summary>
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