using System.ComponentModel.DataAnnotations;

namespace MichaelPavichFinal.Models
{
    /// <summary>
    ///     Defines the LoginViewModel class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public class LoginViewModel
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the username.
        /// </summary>
        /// <value>
        ///     The username.
        /// </value>
        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(255)]
        public string Username { get; set; }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        /// <value>
        ///     The password.
        /// </value>
        [Required(ErrorMessage = "Please enter a password.")]
        [StringLength(255)]
        public string Password { get; set; }

        /// <summary>
        ///     Gets or sets the return URL.
        /// </summary>
        /// <value>
        ///     The return URL.
        /// </value>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [remember me].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [remember me]; otherwise, <c>false</c>.
        /// </value>
        public bool RememberMe { get; set; }

        #endregion
    }
}