using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListingTodos.Models
{
    public class User
    {
        public long Id { get; set; }
        public string UserName {get; set;}
        public string Name { get; set; }

        public List<Todo> Todos { get; set; }
    }
}
