using System;
using System.Collections.Generic;

namespace OOP_Organization
{
    class Department
    {
        #region Constructor;

        /// <summary>
        /// Constructor for MAIN Department Class
        /// </summary>
        /// <param name="Name">Department NAME</param>
        /// <param name="ParentDepartment">Parent Departmen NAME</param>
        public Department(string Name,                       
                          string ParentDepartment)
        {
            this.name = Name;
            this.dateOfCreation = DateTime.Now;
            this.NumberOfEmployees = 0;
            this.NumberOfDepartments = 0;
            this.parentDepartment = ParentDepartment;
            employees = new List<Employee>();
            departments = new List<Department>();           
        }

        #endregion Constructor

        #region Fields;

        protected string name { get; set; } //Name of Department
        protected DateTime dateOfCreation { get; set; } //Dato Of Department Creation
        protected int numberOfEmployees { get; set; } //Number Of Employees in Depatment
        protected int numberOfDepartments { get; set; } //Number Of Departments in Department
        protected string parentDepartment { get; set; } //Parent Department of the Department
        public List<Department> departments; //List if Departments in the Department
        public List<Employee> employees; //List of Employees in the Department
        protected Repository repository; //Repository with all Company DATA

        #endregion Fields


        #region Properties;

        public string Name //Name Property
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public DateTime DateOfCreation //Date Of Creation Property
        {
            get { return this.dateOfCreation; }
        }

        public int NumberOfEmployees //Number Of Employees Property
        {
            get { return this.numberOfDepartments; }
            set { this.numberOfDepartments = value; }
        }

        public int NumberOfDepartments //Number Of Departments Property
        {
            get { return this.numberOfEmployees; }
            set { this.numberOfEmployees = value; }
        }

        public string ParentDepartment //Parent Department Property
        {
            get { return this.parentDepartment; }
            set { this.parentDepartment = value; }
        }

        public Repository Repository //Repository Property
        {
            get { return this.repository; }
            set { this.repository = value; AddMeToCompany(); }
        }

        #endregion Properties


        #region Methods;

        /// <summary>
        /// Method to ADD Department to List of Parent Department and ADD +1 to Parent Department Number Of Departments
        /// </summary>
        private void AddMeToCompany()
        {
            if (parentDepartment == repository.company.Name)
            {
                repository.company.departments.Add(this);
                ++repository.company.NumberOfDepartments;
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

                father.departments.Add(this);
                ++father.NumberOfDepartments;
                ++repository.company.NumberOfDepartments;
            }
        }

        /// <summary>
        /// Method to RETURN Parent Department Class
        /// </summary>
        /// <param name="departments">List of Departmets to FIND Parent Department</param>
        /// <returns></returns>
        Department fatherDepartment(List<Department> departments)
        {
            return departments.Find(item => item.Name == parentDepartment);
        }

        #endregion Methods
    }
}
