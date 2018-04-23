using ListingTodos.Entities;
using ListingTodos.Models;
using System.Linq;

namespace ListingTodos.Repositories
{
    public class LoginRepository
    {
        private TodoContext todoContext;

        public LoginRepository(TodoContext todoContext)
        {
            this.todoContext = todoContext;
        }

        public User GetUser(string username)
        {
            return todoContext.Users.FirstOrDefault(u => u.UserName.Equals(username));
        }

        public void AddUser(User newUser)
        {
            todoContext.Users.Add(newUser);
            todoContext.SaveChanges();
        }
    }
}
