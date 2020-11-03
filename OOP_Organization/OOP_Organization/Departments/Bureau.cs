using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Organization
{
    class Bureau : Department
    {
        public Bureau(string ParentDepartment,
                      string Name)
            : base(Name, 
                  ParentDepartment)
        { }

        public Bureau() : this( "", "") { }
    }    
}
