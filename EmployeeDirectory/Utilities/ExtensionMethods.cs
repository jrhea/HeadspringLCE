using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using EmployeeDirectory.CustomAttributes;

namespace EmployeeDirectory.Utilities
{
    public static class ExtensionMethods
    {
        //This extension method finds properties of class Type with properties decorated with Attributes
        //of type T (extends IAttribute) with Value property of type S equal to s
        public static List<String> getMatchingPropertyNames<T,S>( this Type type, S s) where T : class, IAttribute<S>
        {
            List<String> result = new List<String>();
            PropertyInfo[] props = type.GetProperties();

            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    T filterAttr = attr as T;
                    if (filterAttr != null &&  filterAttr.Value.Equals(s))
                    {
                        result.Add(prop.Name);
                    }
                }
            }
            return result;
        }
    }
}