using ListingTodos.Models;
using ListingTodos.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ListingTodos.Controlls
{
    [Route("todo")]
    public class TodoController : Controller
    {
        private TodoRepository todoRepository;

        public TodoController(TodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        [HttpGet("")]
        [Route("list")]
        [Authorize(Policy = "MustBeAdmin")]
        public IActionResult List([FromQuery] bool isActive)
        {
            var listAll = todoRepository.ListAll();
            var listActive = todoRepository.IsActive();

            if (isActive == false)
                return View(listAll);
            else
                return View(listActive);
            //return View(isActive == false ? listAll : listActive);
            //return View(listAll);
        }

        [HttpGet("list/{username}")]
        public IActionResult List([FromRoute]string username)
        {
            var listAll = todoRepository.ListAll();
            var listByUser = todoRepository.ListByUser(username);

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
