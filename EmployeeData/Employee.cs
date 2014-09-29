namespace EmployeeData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;
    using EmployeeData.CustomAttributes;

    /// <summary>
    /// Employee object
    /// </summary>
    [Table("Employee")]
    [DataContract]
    public class Employee
    {
        /// <summary>
        /// Primary identifier of the object.  Also, represents the login id of the employee.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Last name of the employee.
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Numbers and special characters are not allowed in the name.")]
        [DisplayName("Last Name")]
        [Searchable(true)]
        public string LastName { get; set; }

        /// <summary>
        /// First Name of the employee.
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Numbers and special characters are not allowed in the name.")]
        [DisplayName("First Name")]
        [FilterUIHintAttribute("Searchable")]
        [Searchable(true)]
        public string FirstName { get; set; }

        /// <summary>
        /// Employee's work number.
        /// </summary>
        [DataMember]
        [StringLength(15)]
        [DisplayName("Work Phone")]
        [Searchable(false)]
        public string WorkPhone { get; set; }

        /// <summary>
        /// Employee's cell phone number.
        /// </summary>
        [DataMember]
        [StringLength(15)]
        [DisplayName("Cell Phone")]
        [Searchable(false)]
        public string CellPhone { get; set; }

        /// <summary>
        /// Employee's home phone number
        /// </summary>
        [DataMember]
        [StringLength(15)]
        [DisplayName("Home Phone")]
        [Searchable(false)]
        public string HomePhone { get; set; }

        /// <summary>
        /// Employee's email address
        /// </summary>
        [DataMember]
        [Required]
        [Searchable(false)]
        public string Email { get; set; }

        /// <summary>
        /// Employee's job title.
        /// </summary>
        [DataMember]
        [DisplayName("Job Title")]
        [FilterUIHintAttribute("Searchable")]
        [Searchable(true)]
        public string JobTitle { get; set; }

        /// <summary>
        /// Work location of the employee.
        /// </summary>
        [DataMember]
        [DisplayName("Location")]
        [FilterUIHintAttribute("Searchable")]
        [Searchable(true)]
        public string Location { get; set; }

        /// <summary>
        /// Associated role.
        /// </summary>
        [DataMember]
        public int RoleId { get; set; }

    }

}
