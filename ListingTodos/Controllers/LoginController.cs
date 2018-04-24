using ListingTodos.Models;
using ListingTodos.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Login([FromForm]string username)
        {
            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Login");
            else
                return Redirect($"/todo/list/{username}");
            //var identity = new ClaimsIdentity(new[]
            //{
            //    new Claim(ClaimTypes.Name, username),
            //    new Claim(ClaimTypes.Role, "admin")
            //}, CookieAuthenticationDefaults.AuthenticationScheme);

            //var principal = new ClaimsPrincipal(identity);

            //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            //return Redirect($"/todo/list/{username}");
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
