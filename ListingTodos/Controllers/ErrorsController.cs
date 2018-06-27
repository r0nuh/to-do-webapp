using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ListingTodos.Controllers
{
    public class ErrorsController : Controller
    {
        public IActionResult Index()
        {
            return View("Error");
        }

        public IActionResult Error(string id)
        {
            if (id.Equals("404"))
            {
                return View("Error404");
            }

            return View("Error");
        }
    }
}