namespace EmployeeDirectory.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using EmployeeDirectory.CustomAttributes;

    [Table("Employee")]
    public partial class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Numbers and special characters are not allowed in the name.")]
        [Display(Name = "Last Name")]
        [Searchable(true)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Numbers and special characters are not allowed in the name.")]
        [Display(Name = "First Name")]
        [FilterUIHintAttribute("Searchable")]
        [Searchable(true)]
        public string FirstName { get; set; }

        [StringLength(15)]
        [Display(Name = "Work Phone")]
        [Searchable(false)]
        public string WorkPhone { get; set; }

        [StringLength(15)]
        [Display(Name = "Cell Phone")]
        [Searchable(false)]
        public string CellPhone { get; set; }

        [StringLength(15)]
        [Display(Name = "Home Phone")]
        [Searchable(false)]
        public string HomePhone { get; set; }

        [Required]
        [Searchable(false)]
        public string Email { get; set; }

        public int JobTitleId { get; set; }

        public int LocationId { get; set; }

        [Display(Name = "Job Title")]
        [FilterUIHintAttribute("Searchable")]
        [Searchable(true)]
        public virtual JobTitle JobTitle { get; set; }

         [Display(Name = "Location")]
         [FilterUIHintAttribute("Searchable")]
         [Searchable(true)]
        public virtual Location Location { get; set; }
    }
}
