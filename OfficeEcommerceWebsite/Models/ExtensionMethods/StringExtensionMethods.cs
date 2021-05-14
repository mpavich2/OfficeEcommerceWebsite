using System.Text;

namespace OfficeEcommerceWebsite.Models
{
    /// <summary>
    ///     Defines the StringExtensions class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public static class StringExtensions
    {
        #region Methods

        /// <summary>
        ///     Slugs the specified s.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public static string Slug(this string s)
        {
            var sb = new StringBuilder();
            foreach (var c in s)
            {
                if (!char.IsPunctuation(c) || c == '-')
                {
                    sb.Append(c);
                }
            }

            return sb.ToString().Replace(' ', '-').ToLower();
        }

        /// <summary>
        ///     Equalses the no case.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="toCompare">The tocompare.</param>
        /// <returns></returns>
        public static bool EqualsNoCase(this string s, string toCompare)
        {
            return s?.ToLower() == toCompare?.ToLower();
        }

        /// <summary>
        ///     Converts the string representation of a number to an integer.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public static int ToInt(this string s)
        {
            int.TryParse(s, out var id);
            return id;
        }

        /// <summary>
        ///     Capitalizes the specified s.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public static string Capitalize(this string s)
        {
            return s?.Substring(0, 1)?.ToUpper() + s?.Substring(1);
        }

        #endregion
    }
}