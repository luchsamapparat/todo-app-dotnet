using System;

namespace SsrTodo.Domain
{
    public class Task
    {
        public string Id { get; init; }
        public string Description { get; init; }
        public DateTime? DueDate { get; init; }
        public bool IsCompleted { get; private set; } = false;
        public DateTime CompletedDate { get; private set; }

        public Task(string description, DateTime? dueDate)
        {
            Id = Guid.NewGuid().ToString();
            this.Description = description;
            this.DueDate = dueDate;
        }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
            CompletedDate = DateTime.Now;
        }
    }
}