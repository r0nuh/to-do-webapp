using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ListingTodos.Models
{
    public class User
    {
        public long Id { get; set; }
        [Required]
        public string UserName {get; set; }
        public string Name { get; set; }
        //public string Email { get; set; }
        //public bool EmailConfirmed { get; set; }
        //public int AccessFailedCount { get; set; }
        //public virtual string PasswordHash { get; set; }
        //public ICollection<Claim> Claims { get; private set; }
        //public bool Role { get; set; }

        public List<Todo> Todos { get; set; }
    }
}
