using OOP_Organization.Employees;

namespace OOP_Organization
{
    class HeadOfDepartment : Employee, ISalary
    {

        #region Fields;

        float previouseSalary = 0; //Previouse Salary to COUNT Head Of Organization Salary correctly
        bool salaryAdded = false; //Boolen to CHECK if Sallry was ADDED before to Head Of Organization 

        #endregion Fields


        #region Constructor;

        /// <summary>
        /// Constructor DERIVED from Employee Class
        /// </summary>
        /// <param name="Number">Employee Number</param>
        /// <param name="Name">Employee Name</param>
        /// <param name="LastName">Employee Last Name</param>
        /// <param name="Age">Employee Name</param>
        /// <param name="Department">Employee Department</param>
        /// <param name="DaysWorked">Employee Days Worked</param>
        public HeadOfDepartment(int Number,
                                string Name,
                                string LastName,
                                int Age,
                                string Department,
                                int DaysWorked)
            : base(Number,
                   Name,
                   LastName,
                   Age,
                   Department,
                   DaysWorked)
        { }

        /// <summary>
        /// Default Constructor for HeadOfDepartment
        /// </summary>
        public HeadOfDepartment() : this(1, "", "", 0, "", 0) { }

        #endregion Constructor

        #region Methods;

        /// <summary>
        /// Method to ADD Salary to Head Of Organization
        /// </summary>
        public void AddSalary()
        {
            var headOfOrganization = repository.company.employees[0];

            if (salary < 1300)
            {
                if (!salaryAdded)
                {
                    headOfOrganization.Salary += 1300;
                    salaryAdded = true;
                }
            }
            else
            {
                if (!salaryAdded)
                {
                    headOfOrganization.Salary += salary;
                    salaryAdded = true;
                }
                else
                {
                    headOfOrganization.Salary -= previouseSalary;
                    headOfOrganization.Salary += salary;
                }
            }
        }

        /// <summary>
        /// Method to add Salary to other Head Of The Department (if one exists)
        /// </summary>
        /// <param name="headOfDepartment"></param>
        public void AddSalary(Employee headOfDepartment) { }

        /// <summary>
        /// Overrided Salary Property to count Head Of Organization Salary as soon as THIS Head Of Departmetnt GETS Salary
        /// </summary>
        public override float Salary
        {
            get { return this.salary; }
            set { previouseSalary = this.salary; this.salary = value; AddSalary(); }
        } 

        #endregion Methods
    }
}
