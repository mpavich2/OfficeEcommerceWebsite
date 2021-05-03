using Microsoft.AspNetCore.Mvc;

namespace MichaelPavichFinal.Controllers
{
    /// <summary>
    ///     Defines the ContactController class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class ContactController : Controller
    {
        #region Methods

        /// <summary>
        ///     Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}