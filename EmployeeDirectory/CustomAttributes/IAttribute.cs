﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.CustomAttributes
{
    public interface IAttribute<T>
    {
        T Value { get; set; }
    }
}
