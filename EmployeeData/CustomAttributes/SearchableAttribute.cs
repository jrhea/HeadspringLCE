using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeData.CustomAttributes
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class Searchable : System.Attribute, IAttribute<Boolean>
    {
        public Boolean Value{ get; set; }

        public Searchable(bool isSearchable)
        {
            Value = isSearchable;
        }
    }
}