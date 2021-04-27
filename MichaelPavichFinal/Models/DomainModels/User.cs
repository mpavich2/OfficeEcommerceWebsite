using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MichaelPavichFinal.Models
{
    /// <summary>
    /// Defines the User class.
    /// </summary>
    /// <author>
    /// Michael Pavich
    /// </author>
    /// <date>
    /// Started 4/13/2021
    /// </date>
    /// <seealso cref="Microsoft.AspNetCore.Identity.IdentityUser" />
    public class User : IdentityUser
    {
        /// <summary>
        /// Gets or sets the role names.
        /// </summary>
        /// <value>
        /// The role names.
        /// </value>
        [NotMapped]
        public IList<string> RoleNames { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }
    }
}
