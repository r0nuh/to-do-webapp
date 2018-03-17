using ListingTodos.Entities;
using ListingTodos.Models;
using ListingTodos.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ListingTodos.Repositories
{
    public class TodoRepository
    {
        private TodoContext todoContext;
        private TodoViewModel todoViewModel;

        public TodoRepository(TodoContext todoContext, TodoViewModel todoViewModel)
        {
            this.todoContext = todoContext;
            this.todoViewModel = todoViewModel;
        }

        public TodoViewModel ListAll()
        {
            todoViewModel.Users = todoContext.Users.ToList();
            todoViewModel.Todos = todoContext.Todos.ToList();
            
            return todoViewModel;
        }

        public TodoViewModel IsActive()
        {
            todoViewModel.Users = todoContext.Users.ToList();
            todoViewModel.Todos = todoContext.Todos.Where(x => x.IsDone == false).ToList();

            return todoViewModel;
        }

        public TodoViewModel ListByUser(string username)
        {
            var user = todoContext.Users.FirstOrDefault(x => x.Username.Equals(username));
            todoViewModel.Todos = todoContext.Todos.Where(t => t.User.Equals(user)).ToList();
            todoViewModel.Users = todoContext.Users.Where(u => u.Username.Equals(username)).ToList();

            return todoViewModel;
        }

        public void AddTodo(string title)
        {
            Todo newTodo = new Todo()
            {
                Title = title
            };
            todoContext.Todos.Add(newTodo);

            todoContext.SaveChanges();
        }

        public void Remove(long id)
        {
            Todo deleted = todoContext.Todos.FirstOrDefault(x => x.Id == id);
            todoContext.Todos.Remove(deleted);
            todoContext.SaveChanges();
        }

        public Todo TodoDetails(long id)
        {
            return todoContext.Todos.FirstOrDefault(x => x.Id == id);
        }

        public void Edit(long id, Todo edited)
        {
            todoContext.Todos.FirstOrDefault(x => x.Id == id).Title = edited.Title;
            todoContext.Todos.FirstOrDefault(x => x.Id == id).IsDone = edited.IsDone;
            todoContext.Todos.FirstOrDefault(x => x.Id == id).IsUrgent = edited.IsUrgent;

            todoContext.SaveChanges();
        }
    }
}
