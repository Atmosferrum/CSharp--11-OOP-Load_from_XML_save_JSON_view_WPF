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
using System.Xml;

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

            manualDeserializeXML(path);
        }

        #endregion Constructor;

        #region Methods;

        void manualDeserializeXML(string path)
        {
            string xml = File.ReadAllText(path);
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            var companyXML = XDocument.Parse(xml)
                                         .Descendants("OOP_Organization.Company")
                                         .ToList();

            var bureauXML = XDocument.Parse(xml)
                                         .Descendants("OOP_Organization.Company")
                                         .Descendants("OOP_Organization.Bureau")
                                         .ToList();

            var divisiontXML = XDocument.Parse(xml)
                                         .Descendants("OOP_Organization.Company")
                                         .Descendants("OOP_Organization.Bureau")
                                         .Descendants("OOP_Organization.Division")
                                         .ToList();

            companyXML.Concat(bureauXML).Concat(divisiontXML);

            foreach (var dept in companyXML)
            {
                switch ((string)dept.Attribute("parentDepartment"))
                {
                    case companyName:
                        AddDepartment(new Bureau(dept.Attribute("name").Value,
                                      Convert.ToString(dept.Attribute("parentDepartment").Value),
                                      this));
                        break;
                    case "":
                        new Company(dept.Attribute("name").Value);
                        break;
                    default:
                        AddDepartment(new Division(dept.Attribute("name").Value,
                                      Convert.ToString(dept.Attribute("parentDepartment").Value),
                                      this));
                        break;
                }
            }

            XmlNodeList employeeList = doc.GetElementsByTagName("EMPLOYEE");

            foreach(XElement emply in employeeList)
            {
                switch((int)emply.Attribute("number"))
                {
                    case 0:
                        switch ((string)emply.Attribute("Department"))
                        {
                            case companyName:
                                AddEmployee(new HeadOfOrganization(Convert.ToInt32(emply.Attribute("number").Value),
                                            emply.Attribute("name").Value,
                                            emply.Attribute("lastName").Value,
                                            Convert.ToInt32(emply.Attribute("age").Value),
                                            emply.Attribute("department").Value,
                                            Convert.ToInt32(emply.Attribute("daysWorked").Value),
                                            this));
                                break;
                            default:
                                AddEmployee(new HeadOfDepartment(Convert.ToInt32(emply.Attribute("number").Value),
                                            emply.Attribute("name").Value,
                                            emply.Attribute("lastName").Value,
                                            Convert.ToInt32(emply.Attribute("age").Value),
                                            emply.Attribute("department").Value,
                                            Convert.ToInt32(emply.Attribute("daysWorked").Value),
                                            this));
                                break;
                        }
                        break;
                    case 1:
                        switch ((int)emply.Attribute("Salary"))
                        {
                            case 500:
                                AddEmployee(new Intern(Convert.ToInt32(emply.Attribute("number").Value),
                                           emply.Attribute("name").Value,
                                           emply.Attribute("lastName").Value,
                                           Convert.ToInt32(emply.Attribute("age").Value),
                                           emply.Attribute("department").Value,
                                           Convert.ToInt32(emply.Attribute("daysWorked").Value),
                                           this));
                                break;
                            default:
                                AddEmployee(new Worker(Convert.ToInt32(emply.Attribute("number").Value),
                                           emply.Attribute("name").Value,
                                           emply.Attribute("lastName").Value,
                                           Convert.ToInt32(emply.Attribute("age").Value),
                                           emply.Attribute("department").Value,
                                           Convert.ToInt32(emply.Attribute("daysWorked").Value),
                                           this));
                                break;
                        }
                        break;
                }
            }

            ShowCompany();
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
