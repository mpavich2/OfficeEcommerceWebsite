using System.Threading.Tasks;
using MichaelPavichFinal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MichaelPavichFinal.Controllers
{
    /// <summary>
    ///     Defines the AccountController class. Inherits from controller.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class AccountController : Controller
    {
        #region Data members

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AccountController" /> class.
        /// </summary>
        /// <param name="userMngr">The user MNGR.</param>
        /// <param name="signInMngr">The sign in MNGR.</param>
        public AccountController(UserManager<User> userMngr,
            SignInManager<User> signInMngr)
        {
            this.userManager = userMngr;
            this.signInManager = signInMngr;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the page to register a new user.
        /// </summary>
        /// <returns>the register view</returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        ///     Registers the new user into the database.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>the same view if invalid; otherwise, the index view</returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User {
                    UserName = model.Username, FirstName = model.FirstName, LastName = model.Lastname,
                    Email = model.Email
                };
                var result = await this.userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await this.signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        /// <summary>
        ///     Logs the user out.
        /// </summary>
        /// <returns>The index view.</returns>
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await this.signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        ///     Brings the user to the login view.
        /// </summary>
        /// <param name="returnURL">The return URL.</param>
        /// <returns>the login view</returns>
        [HttpGet]
        public IActionResult LogIn(string returnURL = "")
        {
            var model = new LoginViewModel {ReturnUrl = returnURL};
            return View(model);
        }

        /// <summary>
        ///     Logs the user in.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The index view if valid; otherwise, the same view</returns>
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await this.signInManager.PasswordSignInAsync(
                    model.Username, model.Password, model.RememberMe,
                    false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) &&
                        Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid username/password.");
            return View(model);
        }

        /// <summary>
        ///     Brings the user to the access denied view
        /// </summary>
        /// <returns>the access denied view</returns>
        public ViewResult AccessDenied()
        {
            return View();
        }

        #endregion
    }
}