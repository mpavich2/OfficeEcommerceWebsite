namespace OfficeEcommerceWebsite.Models
{
    /// <summary>
    ///     Defines the Operation class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public static class Operation
    {
        #region Methods

        /// <summary>
        ///     Determines whether the specified action is add.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     <c>true</c> if the specified action is add; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAdd(string action)
        {
            return action.EqualsNoCase("add");
        }

        /// <summary>
        ///     Determines whether the specified action is delete.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     <c>true</c> if the specified action is delete; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDelete(string action)
        {
            return action.EqualsNoCase("delete");
        }

        #endregion
    }
}