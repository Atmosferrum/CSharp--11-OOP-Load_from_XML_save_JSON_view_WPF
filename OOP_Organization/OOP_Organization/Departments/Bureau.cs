namespace OOP_Organization
{
    class Bureau : Department
    {

        #region Constructor;

        /// <summary>
        /// Constructor DERIVED from Department Class
        /// </summary>
        /// <param name="Name">Name of Bureau</param>
        /// <param name="ParentDepartment">Parent Department of Bureau</param>
        public Bureau(string Name,
                      string ParentDepartment)
            : base(Name,
                  ParentDepartment)
        { }

        /// <summary>
        /// Default Constructor for Bureau
        /// </summary>
        public Bureau() : this("", "") { }

        #endregion Constructor

    }
}
