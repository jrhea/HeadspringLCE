namespace EmployeeDirectory.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;
    using EmployeeDirectory.CustomAttributes;

    [Table("Employee")]
    public partial class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Numbers and special characters are not allowed in the name.")]
        [DisplayName("Last Name")]
        [Searchable(true)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Numbers and special characters are not allowed in the name.")]
        [DisplayName("First Name")]
        [FilterUIHintAttribute("Searchable")]
        [Searchable(true)]
        public string FirstName { get; set; }

        [StringLength(15)]
        [DisplayName("Work Phone")]
        [Searchable(false)]
        public string WorkPhone { get; set; }

        [StringLength(15)]
        [DisplayName("Cell Phone")]
        [Searchable(false)]
        public string CellPhone { get; set; }

        [StringLength(15)]
        [DisplayName("Home Phone")]
        [Searchable(false)]
        public string HomePhone { get; set; }

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

        public int JobTitleId { get; set; }

        public int LocationId { get; set; }
        
        public virtual JobTitle JobTitle { get; set; }

        public virtual Location Location { get; set; }
    }
}
