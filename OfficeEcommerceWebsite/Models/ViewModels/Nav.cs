namespace OfficeEcommerceWebsite.Models
{
    /// <summary>
    ///     Defines the Nav class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public static class Nav
    {
        #region Methods

        /// <summary>
        ///     Actives the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="current">The current.</param>
        /// <returns></returns>
        public static string Active(string value, string current)
        {
            return value == current ? "active" : "";
        }

        /// <summary>
        ///     Actives the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="current">The current.</param>
        /// <returns></returns>
        public static string Active(int value, int current)
        {
            return value == current ? "active" : "";
        }

        #endregion
    }
}