using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MichaelPavichFinal.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
