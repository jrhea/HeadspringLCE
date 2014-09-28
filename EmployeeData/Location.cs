namespace EmployeeData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;
    using System.ComponentModel;

    [Table("Location")]
    [DataContract]
    public partial class Location
    {
        public Location()
        {
            Employees = new HashSet<Employee>();
        }
        [DataMember]
        public int Id { get; set; }

        [Required]
        [DataMember]
        [DisplayName("Location")]
        public string Description { get; set; }
        [DataMember]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
