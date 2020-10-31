using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
//using System.Collections.ObjectModel;
//using System.Collections.Specialized;

namespace OOP_Organization
{
    struct Repository
    {
        #region Fields;

        public List<Employee> employees; //Employees DATA array

        public List<Department> departments; //Departments DATA array

        List<XElement> xElements; //XML Data

        private string path; //PATH to file

        public int employeeIndex; //Current INDEX for employee to add

        public int departmentIndex; //Current INDEX for department to add

        public Company company;

        const string companyName = "Normandy";

        #endregion Fields

        #region Constructor;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Path">Path to file to construct</param>
        public Repository(string Path)
        {
            this.path = Path;
            this.employeeIndex = 0;
            this.departmentIndex = 0;
            employees = new List<Employee>();
            departments = new List<Department>();
            this.xElements = new List<XElement>();

            company = new Company(companyName);

            Create();
            Save();
        }

        #endregion Constructor;

        #region Methods;

        void Create()
        {
            //AddDepartment(new Organization("Organization", DateTime.Now, ""));

            AddDepartment(new Bureau("Management", companyName, this));            
            AddDepartment(new Bureau("Strategy", companyName, this));
            AddDepartment(new Division("Marketing", "Management", this));
            AddDepartment(new Division("PR", "Management", this));
            AddDepartment(new Division("Production", "Strategy", this));
            AddDepartment(new Division("HR", "Strategy", this));

            AddEmloyee(new HeadOfOrganization(0, "Commander", "Shepard", 99, company.Name, 365 * 2, this));

            foreach (Department dept in departments)
            {
                AddEmloyee(new HeadOfDepartment(0, "Liara", "T'Soni", 45, dept.Name,  365, this));
                AddEmloyee(new Worker(1, "Tali", "Zorah", 33, dept.Name, 365, this));
                AddEmloyee(new Worker(1, "Miranda", "Lawson", 41, dept.Name,  185, this));
                AddEmloyee(new Worker(1, "Garrus", "Vakarian", 57, dept.Name, 65, this));
                AddEmloyee(new Intern(1, "Zaeed", "Massani", 23, dept.Name, 365, this));
                AddEmloyee(new Intern(1, "Urdnot", "Wrex", 24, dept.Name, 185, this));
                AddEmloyee(new Intern(1, "Mordin", "Solus", 25, dept.Name, 65, this));
                AddEmloyee(new Intern(1, "Thane", "Krios", 27, dept.Name, 30, this));
            }
        }

        void Save()
        {
            CreateToSave();
        }

        void CreateToSave()
        {
            XElement myCompany = new XElement(company.GetType().ToString());
            XAttribute companyName = new XAttribute("name", company.Name);
            XAttribute companyDateOfCreation = new XAttribute("dateOfCreation", DateTime.Now.ToShortDateString());
            XAttribute companyNumberOfEmployees = new XAttribute("numberOfEmployees", company.NumberOfEmployees);
            XAttribute companyNumberOfDepartments = new XAttribute("numberOfDepartments", company.NumberOfDepartments);
            XAttribute companyParentDepartment = new XAttribute("parentDepartment", "");
            myCompany.Add(companyName,
                          companyDateOfCreation,
                          companyNumberOfEmployees,
                          companyNumberOfDepartments,
                          companyParentDepartment);

            EmployeeToSave(company.Name, ref myCompany);

            xElements.Add(myCompany);

            foreach (Department dept in departments)
            {
                XElement myDepartment = new XElement(dept.GetType().ToString());
                XAttribute departmentName = new XAttribute("name", dept.Name);
                XAttribute departmentDateOfCreation = new XAttribute("dateOfCreation", DateTime.Now.ToShortDateString());
                XAttribute departmentNumberOfEmployees = new XAttribute("numberOfEmployees", dept.NumberOfEmployees);
                XAttribute departmentNumberDepartments = new XAttribute("numberOfDepartments", dept.NumberOfDepartments);
                XAttribute departmentParentDepartment = new XAttribute("parentDepartment", dept.ParentDepartment);
                myDepartment.Add(departmentName,
                                 departmentDateOfCreation,
                                 departmentNumberOfEmployees,
                                 departmentNumberDepartments,
                                 departmentParentDepartment);

                EmployeeToSave(dept.Name, ref myDepartment);

                xElements.Add(myDepartment);
            }

            OrganizeToSave();
        }

        void OrganizeToSave()
        {
            XElement father;
            father = xElements.Find(item => (string)item.Attribute("name") == companyName);

            foreach (XElement x in xElements)
            {
                switch ((string)x.Attribute("parentDepartment"))
                {
                    case "Strategy":
                        XElement strategy;
                        strategy = xElements.Find(item => (string)item.Attribute("name") == "Strategy");
                        strategy.Add(x);
                        break;
                    case "Management":
                        XElement management;
                        management = xElements.Find(item => (string)item.Attribute("name") == "Management");
                        management.Add(x);
                        break;
                    case companyName:
                        father.Add(x);
                        break;
                    default:
                        break;
                }
            }

            father.Save("new.xml");
        }

        void EmployeeToSave(string name, ref XElement dept)
        {
            foreach (Employee emply in employees)
            {
                if (emply.Department == name)
                {
                    XElement myEmployee = new XElement("EMPLOYEE");

                    XAttribute employeeNumber = new XAttribute("number", emply.Number);
                    XAttribute employeeName = new XAttribute("name", emply.Name);
                    XAttribute employeeLastName = new XAttribute("lastName", emply.LastName);
                    XAttribute employeeAge = new XAttribute("age", emply.Age);
                    XAttribute employeeDepartment = new XAttribute("department", emply.Department);
                    XAttribute employeeSalary = new XAttribute("salary", emply.Salary);
                    XAttribute employeeNumberOfProjects = new XAttribute("daysWorked", emply.DaysWorked);

                    myEmployee.Add(employeeNumber, employeeName, employeeLastName, employeeAge, employeeDepartment, employeeSalary, employeeNumberOfProjects);
                    dept.Add(myEmployee);
                }
            }
        }

        void AddEmloyee(Employee newEmployee)
        {
            employees.Add(newEmployee);
            this.employeeIndex++;

        }

        void AddDepartment(Department newDepartment)
        {
            departments.Add(newDepartment);
            this.departmentIndex++;
        }

        #endregion Methods
    }
}
