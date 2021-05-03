using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MichaelPavichFinal.Models
{
    /// <summary>
    ///     Defines the UserViewModel class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public class UserViewModel
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the users.
        /// </summary>
        /// <value>
        ///     The users.
        /// </value>
        public IEnumerable<User> Users { get; set; }

        /// <summary>
        ///     Gets or sets the roles.
        /// </summary>
        /// <value>
        ///     The roles.
        /// </value>
        public IEnumerable<IdentityRole> Roles { get; set; }

        #endregion
    }
}