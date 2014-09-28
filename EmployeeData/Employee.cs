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
    [KnownType(typeof(IEmployee))]
    public partial class Employee : IEmployee
    {
       

    }

}
