namespace EmployeeDirectory.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public int Id { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [StringLength(15)]
        public string WorkPhone { get; set; }

        [StringLength(15)]
        public string CellPhone { get; set; }

        [StringLength(15)]
        public string HomePhone { get; set; }

        [Required]
        public string Email { get; set; }

        public int JobTitleId { get; set; }

        public int LocationId { get; set; }

        public virtual JobTitle JobTitle { get; set; }

        public virtual Location Location { get; set; }
    }
}
