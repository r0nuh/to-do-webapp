using ListingTodos.Models;
using ListingTodos.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ListingTodos.Controllers
{
    [Route("")]
    public class LoginController : Controller
    {
        private LoginRepository loginRepository;

        public LoginController(LoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        [HttpGet("")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("")]
        public IActionResult Login([FromForm]string username)
        {
            if (username == null)
                return RedirectToAction("Login");
            else
                //return Redirect($"/todo/list/{username}");
                return Redirect("/todo/list");
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult AddUser(User user)
        {
            loginRepository.AddUser(user);
            return RedirectToAction("Login");
        }
    }
}
