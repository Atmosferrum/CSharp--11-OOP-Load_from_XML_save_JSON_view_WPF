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

        public List<Department> departments; //List of HEAD Departments in Company
        public List<Employee> employees; //List of HEAD Employees in Company

        private string name; //Name of the Company

        private int numberOfDepartments; //Number of HEAD Departments in Comapny

        private int numberOfEmployees; //Number of HEAD Employees in Company

        private string dateOfCreation; //Company's Date Of Creation

        #endregion Fields

        #region Constructor;

        /// <summary>
        /// Constructor for Company
        /// </summary>
        /// <param name="Name">Name of the Company</param>
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

        public string Name //Name Property
        {
            get { return this.name; }            
        }

        public int NumberOfDepartments //Number Of Departments Property
        {
            get { return this.numberOfDepartments; }
            set { this.numberOfDepartments = value; }
        }

        public int NumberOfEmployees //Number Of Employees Property
        {
            get { return this.numberOfEmployees; }
            set { this.numberOfEmployees = value; }
        }

        #endregion Properties
    }
}
