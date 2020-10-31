using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Organization
{
    abstract class Employee
    {
        #region Fields;

        protected int number;
        protected string name;
        protected string lastName;
        protected int age;
        protected string department;
        private float salary;
        protected int daysWorked;
        protected Repository repository;

        #endregion Fields

        #region Constuctor;

        public Employee(int Number, 
                        string Name, 
                        string LastName, 
                        int Age, 
                        string Department, 
                        int DaysWorked,
                        Repository Repository)
        {
            this.number = Number;
            this.name = Name;
            this.lastName = LastName;
            this.age = Age;
            this.department = Department;
            this.daysWorked = DaysWorked;
            this.repository = Repository;

            AddMeToDepartment();
        }

        

        #endregion Constuctor        

        #region Properties;

        public int Number
        {
            get { return this.number; }
            set { this.number = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string Department
        {
            get { return this.department; }
            set { this.department = value; }
        }

        public float Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }

        public int DaysWorked
        {
            get { return this.daysWorked; }
            set { this.daysWorked = value; }
        }

        #endregion Properties

        #region Methods;
        
        private void AddMeToDepartment()
        {
            if (department == repository.company.Name)
            {
                repository.company.employees.Add(this);
                ++repository.company.NumberOfEmployees;
            }
            else
            {
                Department father = repository.departments.Find(item => item.Name == department);
                father.employees.Add(this);
                ++father.NumberOfEmployees;
                ++repository.company.NumberOfEmployees;
            }
        }

        public string print()
        {
            return $"{this.number}" +
                   $"{this.name,20}" +
                   $"{this.lastName,20}" +
                   $"{this.age,20}" +
                   $"{this.department,20}" +
                   $"{this.salary,20}" +
                   $"{this.daysWorked,20}";
        }

        #endregion Methods
    }
}
