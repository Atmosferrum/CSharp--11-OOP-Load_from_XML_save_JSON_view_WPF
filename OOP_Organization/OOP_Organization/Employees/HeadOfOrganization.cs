namespace OOP_Organization
{
    class HeadOfOrganization : Employee
    {

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
        public HeadOfOrganization(int Number,
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
        /// Default Constructor
        /// </summary>
        public HeadOfOrganization() : this(1, "", "", 0, "", 0) { }

        #endregion Constructor
    }
}


