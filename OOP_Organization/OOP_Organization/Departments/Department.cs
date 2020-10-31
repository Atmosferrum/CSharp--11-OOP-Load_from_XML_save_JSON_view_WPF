using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Organization
{
    abstract class Department
    {
        #region Constructor;

        public Department(string Name,                       
                          string ParentDepartment,
                          Repository Repository)
        {
            this.name = Name;
            this.dateOfCreation = DateTime.Now;
            this.NumberOfEmployees = 0;
            this.NumberOfDepartments = 0;
            this.parentDepartment = ParentDepartment;
            employees = new List<Employee>();
            departments = new List<Department>();
            this.repository = Repository;

            AddMeToCompany();
        }

        private void AddMeToCompany()
        {
            if (parentDepartment == repository.company.Name)
            {
                repository.company.departments.Add(this);
                ++repository.company.NumberOfDepartments;
            }
            else
            {
                Department father = repository.departments.Find(item => item.Name == parentDepartment);
                father.departments.Add(this);
                ++father.NumberOfDepartments;
                ++repository.company.NumberOfDepartments;
            }
        }



        #endregion Constructor

        #region Fields;

        protected string name { get; set; }
        protected DateTime dateOfCreation { get; set; }
        public int numberOfEmployees { get; set; }
        protected int numberOfDepartments { get; set; }
        protected string parentDepartment { get; set; }
        protected List<Department> departments;
        public List<Employee> employees;
        protected Repository repository;

        #endregion Fields


        #region Properties;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public DateTime DateOfCreation
        {
            get { return this.dateOfCreation; }
        }

        public int NumberOfEmployees
        {
            get { return this.numberOfDepartments; }
            set { this.numberOfDepartments = value; }
        }

        public int NumberOfDepartments
        {
            get { return this.numberOfEmployees; }
            set { this.numberOfEmployees = value; }
        }

        public string ParentDepartment
        {
            get { return this.parentDepartment; }
            set { this.parentDepartment = value; }
        }

        #endregion Properties


        #region Methods;

        string print()
        {
            return $"{this.name,15}" +
                   $"{this.dateOfCreation,15}";
        }

        #endregion Methods
    }
}
