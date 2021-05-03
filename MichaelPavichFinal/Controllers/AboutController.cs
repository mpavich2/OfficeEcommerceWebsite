using Microsoft.AspNetCore.Mvc;

namespace MichaelPavichFinal.Controllers
{
    /// <summary>
    ///     Defines the AboutController class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class AboutController : Controller
    {
        #region Methods

        /// <summary>
        ///     Gets the index page.
        /// </summary>
        /// <returns>the index view</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}