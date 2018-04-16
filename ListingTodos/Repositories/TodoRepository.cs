﻿using ListingTodos.Entities;
using ListingTodos.Models;
using ListingTodos.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<TodoViewModel> ListByUserAsync(string username)
        {
            var user = await todoContext.Users.FirstOrDefaultAsync(x => x.UserName.Equals(username));
            todoViewModel.Todos = await todoContext.Todos.Where(t => t.User.Equals(user)).ToListAsync();
            todoViewModel.Users = await todoContext.Users.Where(u => u.UserName.Equals(username)).ToListAsync();

            return todoViewModel;
        }

        public async Task AddTodoAsync(Todo newTodo)
        {
            await todoContext.Todos.AddAsync(newTodo);
            await todoContext.SaveChangesAsync();
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
            todoContext.Todos.FirstOrDefault(x => x.Id == id).DueOn = edited.DueOn;
            todoContext.Todos.FirstOrDefault(x => x.Id == id).IsDone = edited.IsDone;
            todoContext.Todos.FirstOrDefault(x => x.Id == id).IsUrgent = edited.IsUrgent;

            todoContext.SaveChanges();
        }
    }
}
