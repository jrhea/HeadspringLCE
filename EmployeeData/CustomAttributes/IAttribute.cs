using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData.CustomAttributes
{
    public interface IAttribute<T>
    {
        T Value { get; set; }
    }
}
