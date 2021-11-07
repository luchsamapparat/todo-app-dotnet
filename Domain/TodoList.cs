using System.Linq;
using System.Collections.Generic;

namespace SsrTodo.Domain
{
    class TodoList
    {
        private IDictionary<string, Task> tasks = new Dictionary<string, Task>();

        public ICollection<Task> GetTasks()
        {
            return tasks.Values.ToList()
                .Where(task => !task.IsCompleted)
                .OrderBy(task => task.Description)
                .ToList();
        }

        public ICollection<Task> GetCompletedTasks()
        {
            return tasks.Values.ToList()
                .Where(task => task.IsCompleted)
                .OrderBy(task => task.Description)
                .ToList();
        }

        public void AddTask(Task task)
        {
            tasks.Add(task.Id, task);
        }

        public void CompleteTask(string taskId)
        {
            tasks[taskId].MarkAsCompleted();
        }
    }
}