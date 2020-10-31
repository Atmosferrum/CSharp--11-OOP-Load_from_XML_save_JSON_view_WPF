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
                        string ParentDepartment,
                        Repository Repository)
            : base(Name,
                  ParentDepartment,
                  Repository)
        { }
    }
}
