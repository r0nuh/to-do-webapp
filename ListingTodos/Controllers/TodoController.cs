using ListingTodos.Models;
using ListingTodos.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult List([FromQuery] bool isActive)
        {
            if (isActive == false)
                return View(todoRepository.ListAll());
            else
                return View(todoRepository.IsActive());
        }

        [HttpGet("list/{username}")]
        public IActionResult List([FromRoute]string username)
        {
            if (username.Equals("admin"))
                return View(todoRepository.ListAll());
            else
                return View(todoRepository.ListByUser(username));
        }

        [HttpGet("add")]
        public IActionResult Create()
        {
            return View(todoRepository.ListAll().Users);
        }

        [HttpPost("add")]
        public IActionResult AddTodo(Todo todo)
        {
            todoRepository.AddTodo(todo.Title);
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
    }
}
