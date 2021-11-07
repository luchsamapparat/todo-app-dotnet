using System;
using System.Collections.Generic;
using System.Linq;

namespace SsrTodo.Domain
{
    public class TodoListService
    {
        private TodoList todoList = new TodoList();

        public ICollection<Task> GetTasks()
        {
            return todoList.GetTasks();
        }

        public ICollection<Task> GetCompletedTasks()
        {
            return todoList.GetCompletedTasks();
        }

        public void AddTask(string description, DateTime? dueDate)
        {
            todoList.AddTask(new Task(description, dueDate));
        }

        public void CompleteTasks(IEnumerable<string> taskIds)
        {
            if (taskIds == null)
            {
                return;
            }
            taskIds.ToList()
                .ForEach(taskId => todoList.CompleteTask(taskId));
        }
    }
}