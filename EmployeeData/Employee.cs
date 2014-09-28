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

    [Table("Employee")]
    [DataContract]
    public class Employee
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

        [DataMember]
        [DisplayName("Job Title")]
        [FilterUIHintAttribute("Searchable")]
        [Searchable(true)]
        public string JobTitle { get; set; }

        [DataMember]
        [DisplayName("Location")]
        [FilterUIHintAttribute("Searchable")]
        [Searchable(true)]
        public string Location { get; set; }

        [DataMember]
        public int RoleId { get; set; }

    }

}
