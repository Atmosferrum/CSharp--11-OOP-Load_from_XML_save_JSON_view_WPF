using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Organization.Employees;

namespace OOP_Organization
{
    class HeadOfDepartment : Employee, ISalary
    {
        public HeadOfDepartment(int Number, 
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
        { }

        public HeadOfDepartment() : this(1, "", "", 0, "", 0) { }

        public override void CountSalary(Employee headOfDepartment)
        {
            AddSalary();
        }

        public void AddSalary()
        {
            var headOfOrganization = repository.employees.Find(item => (item is HeadOfOrganization) && (item.Department == repository.company.Name));
            headOfOrganization.Salary += Salary;
        }

        public void AddSalary(Employee headOfDepartment)
        {            
            headOfDepartment.Salary += (Salary * 0.15f);

            AddSalary();
        }
    }
}
