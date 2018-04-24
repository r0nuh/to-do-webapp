using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListingTodos.Models
{
    public class User : IdentityUser
    {
        public new long Id { get; set; }
        [Required]
        public override string UserName {get; set;}

        public string Name { get; set; }

        public List<Todo> Todos { get; set; }
    }
}
