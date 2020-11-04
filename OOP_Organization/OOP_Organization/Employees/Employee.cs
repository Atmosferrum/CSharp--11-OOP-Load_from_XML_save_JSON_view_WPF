using System.Collections.Generic;

namespace OOP_Organization
{
    class Employee
    {
        #region Fields;

        protected int number; //Number to get the Employee status (0 - Head Of Department, 1 - Worker or Intern)
        protected string name; //Name of The Employee
        protected string lastName; //Last Name of the Employee
        protected int age; //Age of the Employee
        protected string department; //Department of the Employee
        protected float salary; //Salary of the Employee
        protected int daysWorked; //How many days Employee worked at the Company
        protected Repository repository; //Repository with all Company DATA

        #endregion Fields

        #region Constuctor;

        /// <summary>
        /// Consturctor for MAIN Employee Class
        /// </summary>
        /// <param name="Number">Employee Number</param>
        /// <param name="Name">Employee Name</param>
        /// <param name="LastName">Employee Last Name</param>
        /// <param name="Age">Employee Age</param>
        /// <param name="Department">Employee Department</param>
        /// <param name="DaysWorked">Days Worked by Employee</param>
        public Employee(int Number,
                        string Name,
                        string LastName,
                        int Age,
                        string Department,
                        int DaysWorked)
        {
            this.number = Number;
            this.name = Name;
            this.lastName = LastName;
            this.age = Age;
            this.department = Department;
            this.daysWorked = DaysWorked;
        }

        #endregion Constuctor        

        #region Properties;

        public int Number //Number Property
        {
            get { return this.number; }
            set { this.number = value; }
        }

        public string Name //Name Property
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string LastName //Last Name Property
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public int Age //Age Property
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string Department //Department Property
        {
            get { return this.department; }
            set { this.department = value; }
        }

        public virtual float Salary //Salary Property
        {
            get { return this.salary; }
            set { this.salary = value; }
        }

        public int DaysWorked //Days Worked Property
        {
            get { return this.daysWorked; }
            set { this.daysWorked = value; }
        }

        public Repository Repository //Repository Property
        {
            get { return this.repository; }
            set { this.repository = value; AddMeToDepartment(); }
        }

        #endregion Properties

        #region Methods;

        /// <summary>
        /// Method to ADD Employee to List of Parent Department and ADD +1 to Parent Department Number Of Employees
        /// </summary>
        private void AddMeToDepartment()
        {
            if (department == repository.company.Name)
            {
                repository.company.employees.Add(this);
                ++repository.company.NumberOfEmployees;
            }
            else
            {
                Department father = fatherDepartment(repository.company.departments);

                while (father == null)
                {
                    foreach (Department dept in repository.company.departments)
                    {
                        father = fatherDepartment(dept.departments);
                    }
                }

                if (father.employees.Count > 0)
                    CountSalary(father.employees[0]);

                father.employees.Add(this);
                ++father.NumberOfEmployees;
                ++repository.company.NumberOfEmployees;
            }
        }

        /// <summary>
        /// Method to RETURN Parent Department
        /// </summary>
        /// <param name="departments">List of Departnments to SEARCH</param>
        /// <returns></returns>
        Department fatherDepartment(List<Department> departments)
        {
            return departments.Find(item => item.Name == department);
        }

        /// <summary>
        /// Method to COUNT Salary (OVERRIDED in Children Classes)
        /// </summary>
        /// <param name="headOfDepartment">Head Of Department to INCREASE Salary</param>
        public virtual void CountSalary(Employee headOfDepartment)
        { }

        #endregion Methods
    }
}
