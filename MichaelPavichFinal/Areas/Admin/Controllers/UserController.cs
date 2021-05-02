using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MichaelPavichFinal.Models;

namespace MichaelPavichFinal.Areas.Admin.Controllers
{
    public class UserController : Controller
    {

        public IActionResult Index()
        {

            return View();
        }
    }
}
