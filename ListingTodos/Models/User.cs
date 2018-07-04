using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListingTodos.Models
{
    public class User
    {
        public long Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Username must contain at least 3 characters")] 
        [MaxLength(50, ErrorMessage = "Username can contain max 50 characters")]
        public string UserName {get; set;}
        public string Name { get; set; }

        public List<Todo> Todos { get; set; }
    }
}
