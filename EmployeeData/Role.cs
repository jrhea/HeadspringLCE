namespace EmployeeData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    /// <summary>
    /// This class represents the available system roles.
    /// </summary>
    [Table("Role")]
    [DataContract]
    public partial class Role
    {
        /// <summary>
        /// Unique identifier of the role for programmatic purposes.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Name of the Role.
        /// </summary>
        [Required]
        [StringLength(50)]
        [DataMember]
        [DisplayName("Role")]
        public string Description { get; set; }
    }
}
