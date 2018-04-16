using System;

namespace ListingTodos.Models
{
    public class Todo
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool IsUrgent { get; set; } = false;
        public bool IsDone { get; set; } = false;
        public DateTime AddedOn { get; set; } = DateTime.Now;
        public DateTimeOffset? DueOn { get; set; }

        public User User { get; set; }
    }
}
