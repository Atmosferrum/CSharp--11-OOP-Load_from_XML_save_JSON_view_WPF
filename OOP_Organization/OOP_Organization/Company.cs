using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Organization
{
    class Company
    {

        #region Fields;

        public List<Department> departments;
        public List<Employee> employees;

        private string name;

        public int numberOfDepartments;

        public int numberOfEmployees;

        private string dateOfCreation;

        #endregion Fields

        #region Constructor;

        public Company(string Name)
        {
            this.name = Name;
            departments = new List<Department>();
            employees = new List<Employee>();            
            dateOfCreation = DateTime.Now.ToShortDateString();
            numberOfDepartments = 0;
            numberOfEmployees = 0;
        }

        #endregion Constructor


        #region Properties;

        public string Name
        {
            get { return this.name; }            
        }

        public int NumberOfDepartments
        {
            get { return this.numberOfDepartments; }
            set { this.numberOfDepartments = value; }
        }

        public int NumberOfEmployees
        {
            get { return this.numberOfEmployees; }
            set { this.numberOfEmployees = value; }
        }

        #endregion Properties
    }
}
