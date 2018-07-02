using ListingTodos.Models;
using ListingTodos.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ListingTodos.Controllers
{
    [Route("todo")]
    public class TodoController : Controller
    {
        private TodoRepository todoRepository;
        private LoginRepository loginRepository;

        public TodoController(TodoRepository todoRepository, LoginRepository loginRepository)
        {
            this.todoRepository = todoRepository;
            this.loginRepository = loginRepository;
        }

        [HttpGet("")]
        [Route("list")]
        //[Authorize(Policy = "MustBeAdmin")]
        public async Task<IActionResult> List([FromQuery] bool isActive)
        {
            var listAll = await todoRepository.ListAllAsync();
            var listActive = await todoRepository.IsActiveAsync();

            return View(isActive == false ? listAll : listActive);
        }

        [HttpGet("list/{username?}")]
        public async Task<IActionResult> List([FromRoute]string username)
        {
            ViewBag.User = loginRepository.GetUser(username).Name;
            var listAll = await todoRepository.ListAllAsync();
            var listByUser = await todoRepository.ListByUserAsync(username);

            if (username.Equals("admin"))
                return View(listAll);
            else
                return View(listByUser);
        }

        [HttpGet("add")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTodo(Todo todo)
        {
            await todoRepository.AddTodoAsync(todo);
            return RedirectToAction("List");
        }

        [HttpPost("{id}/delete")]
        public IActionResult Delete(long id)
        {
            todoRepository.Remove(id);
            return RedirectToAction("List");
        }

        [HttpGet("{id}/edit")]
        public IActionResult Edit(long id)
        {
            return View(todoRepository.TodoDetails(id));
        }

        [HttpPost("{id}/edit")]
        public IActionResult Update(long id, Todo todo)
        {
            todoRepository.Edit(id, todo);
            return RedirectToAction("List");
        }

        //[HttpPost()]
        //public async Task<IActionResult> Logout()
        //{
        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        //    return RedirectToAction("Login");
        //}
    }
}
