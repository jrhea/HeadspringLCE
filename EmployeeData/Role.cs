namespace EmployeeData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("Role")]
    [DataContract]
    public partial class Role
    {
        [DataMember]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DataMember]
        [DisplayName("Role")]
        public string Description { get; set; }
    }
}
