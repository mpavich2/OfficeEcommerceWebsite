using System.Collections.Generic;
using System.Threading.Tasks;
using MichaelPavichFinal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MichaelPavichFinal.Areas.Admin.Controllers
{
    /// <summary>
    ///     Defines the UserController class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UserController : Controller
    {
        #region Data members

        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserController" /> class.
        /// </summary>
        /// <param name="userMngr">The user MNGR.</param>
        /// <param name="roleMngr">The role MNGR.</param>
        public UserController(UserManager<User> userMngr,
            RoleManager<IdentityRole> roleMngr)
        {
            this.userManager = userMngr;
            this.roleManager = roleMngr;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var users = new List<User>();
            foreach (var user in this.userManager.Users)
            {
                user.RoleNames = await this.userManager.GetRolesAsync(user);
                users.Add(user);
            }

            var model = new UserViewModel {
                Users = users,
                Roles = this.roleManager.Roles
            };
            return View(model);
        }

        /// <summary>
        ///     Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await this.userManager.DeleteAsync(user);
                if (!result.Succeeded) // if failed
                {
                    var errorMessage = "";
                    foreach (var error in result.Errors)
                    {
                        errorMessage += error.Description + " | ";
                    }

                    TempData["message"] = errorMessage;
                }
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        ///     Adds this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        ///     Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User {UserName = model.Username};
                var result = await this.userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        /// <summary>
        ///     Adds to admin.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddToAdmin(string id)
        {
            var adminRole = await this.roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                TempData["message"] = "Admin role does not exist. "
                                      + "Click 'Create Admin Role' button to create it.";
            }
            else
            {
                var user = await this.userManager.FindByIdAsync(id);
                await this.userManager.AddToRoleAsync(user, adminRole.Name);
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        ///     Removes from admin.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RemoveFromAdmin(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            var result = await this.userManager.RemoveFromRoleAsync(user, "Admin");
            if (result.Succeeded)
            {
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        ///     Deletes the role.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await this.roleManager.FindByIdAsync(id);
            var result = await this.roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        ///     Creates the admin role.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAdminRole()
        {
            var result = await this.roleManager.CreateAsync(new IdentityRole("Admin"));
            if (result.Succeeded)
            {
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}