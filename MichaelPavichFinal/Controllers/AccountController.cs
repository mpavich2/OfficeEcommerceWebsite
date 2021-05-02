using System.Threading.Tasks;
using MichaelPavichFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace MichaelPavichFinal.Controllers
{
    /// <summary>
    /// Defines the AccountController class. Inherits from controller.
    /// </summary>
    /// <author>
    /// Michael Pavich
    /// </author>
    /// <date>
    /// Started 4/13/2021
    /// </date>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="userMngr">The user MNGR.</param>
        /// <param name="signInMngr">The sign in MNGR.</param>
        public AccountController(UserManager<User> userMngr,
            SignInManager<User> signInMngr)
        {
            userManager = userMngr;
            signInManager = signInMngr;
        }

        /// <summary>
        /// Gets the page to register a new user.
        /// </summary>
        /// <returns>the register view</returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Registers the new user into the database.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>the same view if invalid; otherwise, the index view</returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new MichaelPavichFinal.Models.User { UserName = model.Username, FirstName = model.FirstName, LastName = model.Lastname, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        /// <summary>
        /// Logs the user out.
        /// </summary>
        /// <returns>The index view.</returns>
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Brings the user to the login view.
        /// </summary>
        /// <param name="returnURL">The return URL.</param>
        /// <returns>the login view</returns>
        [HttpGet]
        public IActionResult LogIn(string returnURL = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnURL };
            return View(model);
        }

        /// <summary>
        /// Logs the user in.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The index view if valid; otherwise, the same view</returns>
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Username, model.Password, isPersistent: model.RememberMe,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) &&
                        Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid username/password.");
            return View(model);
        }

        /// <summary>
        /// Brings the user to the access denied view
        /// </summary>
        /// <returns>the access denied view</returns>
        public ViewResult AccessDenied()
        {
            return View();
        }
    }
}