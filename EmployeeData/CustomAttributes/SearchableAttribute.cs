using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeData.CustomAttributes
{
    /// <summary>
    /// Any property tagged with this attribute helps identify 
    /// that property as one that can be used for filtering 
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class Searchable : System.Attribute, IAttribute<Boolean>
    {
        /// <summary>
        /// Use reflection to interrogate the value of this attribute property 
        /// to tell the code how to handle the associated property.
        /// </summary>
        public Boolean Value{ get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="isSearchable">Initializes the value property</param>
        public Searchable(bool isSearchable)
        {
            Value = isSearchable;
        }
    }
}