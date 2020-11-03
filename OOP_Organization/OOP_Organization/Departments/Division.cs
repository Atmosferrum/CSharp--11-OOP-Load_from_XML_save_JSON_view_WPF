using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Organization
{
    class Division : Department
    {
        public Division(string Name,
                        string ParentDepartment)
            : base(Name,
                  ParentDepartment)
        { }

        public Division() : this("", "") { }
    }
}
