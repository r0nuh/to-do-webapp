using ListingTodos.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListingTodos.ViewModels
{
    public class TodoViewModel
    {
        public List<User> Users { get; set; } = new List<User>();
        public List<Todo> Todos { get; set; } = new List<Todo>();
    }
}
