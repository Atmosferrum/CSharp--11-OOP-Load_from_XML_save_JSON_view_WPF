using System;
using System.Xml;

namespace OOP_Organization
{
    class Repository
    {
        #region Fields;

        private string path; //PATH to file

        public Company company; //Class of Company that contains all Departments and Employees 

        const string companyName = "Normandy"; //Name of the Company

        #endregion Fields

        #region Constructor;
        /// <summary>
        /// Constructor for Repository
        /// </summary>
        /// <param name="Path">Path to file to construct</param>
        public Repository(string Path)
        {
            this.path = Path;            

            company = new Company(companyName);

            autoDesiarilizationXML(path);
        }

        #endregion Constructor;

        #region Methods;

        /// <summary>
        /// Load & Show Company from XML File
        /// </summary>
        /// <param name="path">Path to Company XML File</param>
        void autoDesiarilizationXML(string path)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);

            XmlElement xRoot = xDoc.DocumentElement;

            XmlNode xCompany = xRoot;

            Company company = new Company(Convert.ToString(xCompany.Attributes.GetNamedItem("name").Value));

            if (xCompany.HasChildNodes)
                Recursion(xCompany);
        }

        /// <summary>
        /// Load inner Departments & Employees of a Company into Classes
        /// </summary>
        /// <param name="father">Parent Department for following Departments & Employees</param>
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

        /// <summary>
        /// Give Employee Valuse for Properties
        /// </summary>
        /// <param name="node">XML Node to get Values</param>
        /// <param name="emply">Employee to add Values</param>
        void DefineEmployeeClass(XmlNode node, Employee emply)
        {
            emply.Number = Convert.ToInt32(node.Attributes.GetNamedItem("number").Value);
            emply.Name = Convert.ToString(node.Attributes.GetNamedItem("name").Value);
            emply.LastName = Convert.ToString(node.Attributes.GetNamedItem("lastName").Value);
            emply.Age = Convert.ToInt32(node.Attributes.GetNamedItem("age").Value);
            emply.Department = Convert.ToString(node.Attributes.GetNamedItem("department").Value);
            emply.DaysWorked = Convert.ToInt32(node.Attributes.GetNamedItem("daysWorked").Value);
            emply.Repository = this;
        }

        /// <summary>
        /// Give Department Values for Properties
        /// </summary>
        /// <param name="node">XML node to get Values</param>
        /// <param name="dept">Department to add Values</param>
        void DefineDepartmentClass(XmlNode node, Department dept)
        {
            dept.Name = Convert.ToString(node.Attributes.GetNamedItem("name").Value);
            dept.ParentDepartment = Convert.ToString(node.Attributes.GetNamedItem("parentDepartment").Value);
            dept.Repository = this;
        }

        #endregion Methods
    }
}
