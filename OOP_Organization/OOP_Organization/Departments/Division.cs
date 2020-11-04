namespace OOP_Organization
{
    class Division : Department
    {

        #region Constructor;

        /// <summary>
        /// Constructor DERIVED from Department Class
        /// </summary>
        /// <param name="Name">Name of the Division</param>
        /// <param name="ParentDepartment">Parent Department for the Division</param>
        public Division(string Name,
                        string ParentDepartment)
            : base(Name,
                  ParentDepartment)
        { }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Division() : this("", "") { } 

        #endregion Constructor
    }
}
