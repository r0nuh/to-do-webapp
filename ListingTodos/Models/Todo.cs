using System;

namespace ListingTodos.Models
{
    public class Todo
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool IsUrgent { get; set; } = false;
        public bool IsDone { get; set; } = false;
        public DateTime Date { get; set; } = DateTime.Now;
        public User User { get; set; }
    }
}
