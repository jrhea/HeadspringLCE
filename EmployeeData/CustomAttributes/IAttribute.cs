using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData.CustomAttributes
{
    /// <summary>
    /// Custom attribute interface that comes in handy for reflectively inspecting
    /// the attributes of class properties.  This is used with generic types 
    /// and prevents havin to use a magic string match so you get compile time 
    /// errors.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAttribute<T>
    {
        /// <summary>
        /// The property that you can programmatically count on existing for
        /// any attribute that implements this interface.
        /// </summary>
        T Value { get; set; }
    }
}
