using Microsoft.AspNetCore.Mvc;

namespace OfficeEcommerceWebsite.Controllers
{
    /// <summary>
    ///     Defines the HomeController class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class HomeController : Controller
    {
        #region Methods

        /// <summary>
        ///     Indexes this instance.
        /// </summary>
        /// <returns>the index view</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}