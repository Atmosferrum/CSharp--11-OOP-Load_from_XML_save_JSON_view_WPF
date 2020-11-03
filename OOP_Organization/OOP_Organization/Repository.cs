using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Xml;

namespace OOP_Organization
{
    class Repository
    {
        #region Fields;

        public List<Employee> employees; //Employees DATA array

        public List<Department> departments; //Departments DATA array

        //List<XElement> xElements; //XML Data

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

            company = new Company(companyName);

            autoDesiarilizationXML(path);
        }

        #endregion Constructor;

        #region Methods;

        void autoDesiarilizationXML(string path)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);

            XmlElement xRoot = xDoc.DocumentElement;

            XmlNode xCompany = xRoot;


            Company company = new Company(Convert.ToString(xCompany.Attributes.GetNamedItem("name").Value));

            if (xCompany.HasChildNodes)
                Recursion(xCompany);

            ShowCompany();
        }

        void Recursion(XmlNode father)
        {
            var nodes = father.ChildNodes;

            foreach (XmlNode child in nodes)
            {
                if (child.Name != "EMPLOYEE")
                {
                    if(Convert.ToString(child.Attributes.GetNamedItem("parentDepartment").Value) == companyName)
                        DefineDepartmentClass(child, new Bureau());
                    else
                        DefineDepartmentClass(child, new Division());

                    if (child.HasChildNodes) Recursion(child);
                }
                else
                {
                    if(child.Attributes.GetNamedItem("department").Value == companyName)                    
                        DefineEmployeeClass(child, new HeadOfOrganization());                    
                    else
                    {
                        if(Convert.ToInt32(child.Attributes.GetNamedItem("number").Value) == 0)
                            DefineEmployeeClass(child, new HeadOfDepartment());
                        else
                        {
                            if(Convert.ToInt32(child.Attributes.GetNamedItem("salary").Value) == 500)
                                DefineEmployeeClass(child, new Intern());
                            else
                                DefineEmployeeClass(child, new Worker());
                        }
                    }                    
                }
            }
        }

        void DefineEmployeeClass(XmlNode node, Employee emply)
        {
            emply.Number = Convert.ToInt32(node.Attributes.GetNamedItem("number").Value);
            emply.Name = Convert.ToString(node.Attributes.GetNamedItem("name").Value);
            emply.LastName = Convert.ToString(node.Attributes.GetNamedItem("lastName").Value);
            emply.Age = Convert.ToInt32(node.Attributes.GetNamedItem("age").Value);
            emply.Department = Convert.ToString(node.Attributes.GetNamedItem("department").Value);
            emply.DaysWorked = Convert.ToInt32(node.Attributes.GetNamedItem("daysWorked").Value);
            emply.Repository = this;

            AddEmployee(emply);
        }

        void DefineDepartmentClass(XmlNode node, Department dept)
        {
            dept.Name = Convert.ToString(node.Attributes.GetNamedItem("name").Value);
            dept.ParentDepartment = Convert.ToString(node.Attributes.GetNamedItem("parentDepartment").Value);
            dept.Repository = this;

            AddDepartment(dept);
        }


        void ShowCompany()
        {
            foreach (Department dept in departments)
            {
                Debug.WriteLine($"{ dept.Name} {dept.ParentDepartment}");
            }

            foreach (Employee emply in employees)
            {
                Debug.WriteLine($"{emply.Name} {emply.Age} {emply.Department}");
            }
        }

        void AddEmployee(Employee newEmployee)
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
