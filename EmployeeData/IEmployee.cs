using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.ComponentModel;
using EmployeeData.CustomAttributes;

namespace EmployeeData
{
    
    public interface IEmployee
    {
       int Id { get; set; }

       string LastName { get; set; }

       string FirstName { get; set; }

       string WorkPhone { get; set; }

       string CellPhone { get; set; }

       string HomePhone { get; set; }

       string Email { get; set; }

       string JobTitle { get; set; }

       string Location { get; set; }

       int RoleId { get; set; }
    }
}
