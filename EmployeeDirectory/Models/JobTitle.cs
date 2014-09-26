namespace EmployeeDirectory.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JobTitle")]
    public partial class JobTitle
    {
        public JobTitle()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
