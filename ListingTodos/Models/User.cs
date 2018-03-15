using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListingTodos.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Username {get; set;}
        public string Name { get; set; }
        public List<Todo> Todos { get; set; }
    }
}
