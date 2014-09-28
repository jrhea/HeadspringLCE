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

namespace EmployeeDAL
{
    [KnownType(typeof(Employee))]
    [DataContract]
    public abstract class IEmployee
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Numbers and special characters are not allowed in the name.")]
        [DisplayName("Last Name")]
        [Searchable(true)]
        public string LastName { get; set; }

        [DataMember]
        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Numbers and special characters are not allowed in the name.")]
        [DisplayName("First Name")]
        [FilterUIHintAttribute("Searchable")]
        [Searchable(true)]
        public string FirstName { get; set; }

        [DataMember]
        [StringLength(15)]
        [DisplayName("Work Phone")]
        [Searchable(false)]
        public string WorkPhone { get; set; }

        [DataMember]
        [StringLength(15)]
        [DisplayName("Cell Phone")]
        [Searchable(false)]
        public string CellPhone { get; set; }

        [DataMember]
        [StringLength(15)]
        [DisplayName("Home Phone")]
        [Searchable(false)]
        public string HomePhone { get; set; }

        [DataMember]
        [Required]
        [Searchable(false)]
        public string Email { get; set; }

        [DisplayName("Job Title")]
        [FilterUIHintAttribute("Searchable")]
        [Searchable(true)]
        public virtual string JobTitleValue
        {
            get
            {
                return JobTitle.Description;
            }
        }

        [DisplayName("Location")]
        [FilterUIHintAttribute("Searchable")]
        [Searchable(true)]
        public virtual string LocationValue
        {
            get
            {
                return Location.Description;
            }
        }
        [DataMember]
        public int JobTitleId { get; set; }

        [DataMember]
        public int LocationId { get; set; }

        [DataMember]
        public int RoleId { get; set; }

        [DataMember]
        public JobTitle JobTitle { get; set; }

        [DataMember]
        public Location Location { get; set; }

        [DataMember]
        public Role Role { get; set; }
    }
}
