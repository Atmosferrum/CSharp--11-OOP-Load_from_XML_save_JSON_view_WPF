using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Organization.Employees;

namespace OOP_Organization
{
    class Intern : Employee, ISalary
    {
        public Intern(int Number, 
                      string Name, 
                      string LastName,
                      int Age, 
                      string Department, 
                      int DaysWorked)
            : base(Number, 
                   Name, 
                   LastName,
                   Age,
                   Department,
                   DaysWorked)
        {
            Salary = 500;
        }

        public Intern() : this(1, "", "", 0,"",0) { }

        public void AddSalary()
        {
            var headOfDeaprtment = repository.employees.Find(item => (item is HeadOfDepartment) && (item.Department == Department));
            headOfDeaprtment.Salary += (Salary * 0.15f);

            var headOfOrganization = repository.employees.Find(item => (item is HeadOfOrganization) && (item.Department == repository.company.Name));
            headOfOrganization.Salary += Salary;
        }
    }
}
