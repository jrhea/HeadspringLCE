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
        //This extension method finds properties of a class that are decorated with Attributes
        //of type T (extends IAttribute) with Value property of type S equal to s
        public static List<PropertyInfo> getMatchingProperties<T, S>(this Type type, S value) where T : class, IAttribute<S>
        {
            List<PropertyInfo> result = new List<PropertyInfo>();
            PropertyInfo[] props = type.GetProperties();

            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    T filterAttr = attr as T;
                    if (filterAttr != null && filterAttr.Value.Equals(value))
                    {
                        result.Add(prop);
                    }
                }
            }
            return result;
        }
        //This extension method finds properties of a class that are decorated with Attributes
        //of type T  with Value property of type S equal to s
        public static List<PropertyInfo> getMatchingProperties<T,S>(this Type type, S value, String propertyName) where T: class
        {
            List<PropertyInfo> result = new List<PropertyInfo>();
            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    T filterAttr = attr as T;
                    if (filterAttr != null && filterAttr.GetType().GetProperty(propertyName).GetValue(filterAttr).Equals(value))
                    {
                        result.Add(prop);
                    }
                }
            }
            return result;
        }

        //This extension method finds properties of a class that are decorated with Attributes
        //of type T (extends IAttribute) with Value property of type S equal to s
        public static List<PropertyInfo> getMatchingProperties<T>(this Type type) where T : class
        {
            List<PropertyInfo> result = new List<PropertyInfo>();
            PropertyInfo[] props = type.GetProperties();

            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    T filterAttr = attr as T;
                    if (filterAttr != null)
                    {
                        result.Add(prop);
                    }
                }
            }
            return result;
        }

    }
}