using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Organization
{
    class HeadOfOrganization : Employee
    {
        public HeadOfOrganization(int Number, 
                                  string Name, 
                                  string LastName, 
                                  int Age, 
                                  string Department,  
                                  int DaysWorked,
                                  Repository Repository) 
            : base(Number, 
                   Name, 
                   LastName, 
                   Age, 
                   Department,
                   DaysWorked,
                   Repository)
        {}

        
    }
}
