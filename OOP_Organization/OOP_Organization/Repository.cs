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
    struct Repository
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
            //this.xElements = new List<XElement>();

            company = new Company(companyName);

            //manualDeserializeXML(path);

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

            for (int i = 0; i < employees.Count; i++)
            {
                var tempEmployee = employees[i];
                var properties = tempEmployee.GetType().GetProperties();
                employees[i] = ReturnEmployeeTypes(employees[i]);
                var anotherProperties = employees[i].GetType().GetProperties();
                foreach (var property in properties)
                {
                    foreach (var anotherPropertie in anotherProperties)
                        anotherPropertie.SetValue(employees[i], property.GetValue(tempEmployee));
                }
                Debug.WriteLine($"{employees[i].GetType().Name}" +
                                $"\n -------o-------");
            }

            foreach (Department dept in departments) ReturnDepartmentTypes(dept);

            ShowCompany();
        }

        Employee ReturnEmployeeTypes(Employee emply)
        {
            switch (emply.Department)
            {
                case "Normandy":
                    return emply as HeadOfOrganization;
                default:
                    switch (emply.Number)
                    {
                        case 0:
                            return emply as HeadOfDepartment;
                        default:
                            switch (emply.Salary)
                            {
                                case 500:
                                    return emply as Intern;
                                default:
                                    return emply as Worker;
                            }  
                    }
            }    
        }

        Department ReturnDepartmentTypes(Department dept)
        {
            switch (dept.ParentDepartment)
            {
                case "Normandy":
                    return dept as Bureau;
                default:
                    return dept as Division;
            }
        }

        void Recursion(XmlNode father)
        {
            var nodes = father.ChildNodes;  

            foreach(XmlNode child in nodes)
            {
                if(child.Name != "EMPLOYEE")
                {
                    Department department = new Department(Convert.ToString(child.Attributes.GetNamedItem("name").Value),
                                                           Convert.ToString(child.Attributes.GetNamedItem("parentDepartment").Value),
                                                           this);
                    AddDepartment(department);

                    if (child.HasChildNodes)
                        Recursion(child);
                    
                }
                else
                {
                    Employee employee = new Employee(Convert.ToInt32(child.Attributes.GetNamedItem("number").Value),
                                                     Convert.ToString(child.Attributes.GetNamedItem("name").Value),
                                                     Convert.ToString(child.Attributes.GetNamedItem("lastName").Value),
                                                     Convert.ToInt32(child.Attributes.GetNamedItem("age").Value),
                                                     Convert.ToString(child.Attributes.GetNamedItem("department").Value),
                                                     Convert.ToInt32(child.Attributes.GetNamedItem("daysWorked").Value),
                                                     this);
                    AddEmployee(employee);
                }
            }          
        }


        void ShowCompany()
        {
            foreach(Department dept in departments)
            {
                Debug.WriteLine($"{ dept.Name} {dept.ParentDepartment}");
            }

            foreach(Employee emply in employees)
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
