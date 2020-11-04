using OOP_Organization.Employees;

namespace OOP_Organization
{
    class Worker : Employee, ISalary 
    {

        #region Constructor;

        /// <summary>
        /// Constructor DERIVED from Employee Class (But with differnet Salary)
        /// </summary>
        /// <param name="Number">Employee Number</param>
        /// <param name="Name">Employee Name</param>
        /// <param name="LastName">Employee Last Name</param>
        /// <param name="Age">Employee Name</param>
        /// <param name="Department">Employee Department</param>
        /// <param name="DaysWorked">Employee Days Worked</param>
        public Worker(int Number,
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
        {
            Salary = 12 * 8 * 30;

        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Worker() : this(1, "", "", 0, "", 0) { }

        #endregion Constructor

        /// <summary>
        /// Method to GET right Head Of The Department
        /// </summary>
        /// <param name="headOfDepartment">Head Of The department</param>
        public override void CountSalary(Employee headOfDepartment)
        {
            AddSalary(headOfDepartment);
        }

        /// <summary>
        /// Method to ADD Salary to Head Of The Department
        /// </summary>
        /// <param name="headOfDepartment">Head Of The Department to add Salary</param>
        public void AddSalary(Employee headOfDepartment)
        {            
            headOfDepartment.Salary += (Salary * 0.15f);

            AddSalary();
        }

        /// <summary>
        /// Method to ADD Salary to Head Of Organization
        /// </summary>
        public void AddSalary()
        {
            var headOfOrganization = repository.company.employees[0];
            headOfOrganization.Salary += Salary;
        }
    }
}
