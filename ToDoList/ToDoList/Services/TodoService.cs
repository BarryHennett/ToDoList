using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Services
{
    internal class TodoService : TodoServiceInterface
    {
        private List<Todo> _todoItems;
        public TodoService()
        {
            _todoItems = new List<Todo>
            {
                new Todo{Id = 1, Title="Task1", IsCompleted = false},
                new Todo{Id = 2, Title="Task2", IsCompleted = true},
                new Todo{Id = 3, Title="Task3", IsCompleted = false},
            };
        }

        public async Task<List<Todo>> GetTodos()
        {
            return await Task.FromResult(_todoItems);
        }

        public async Task AddTodoAsync(Todo todo)
        {
            todo.Id = _todoItems.Count + 1;
            _todoItems.Add(todo);
            await Task.CompletedTask;
        }

        public async Task ToggleTodoCompleteAsync(Todo todo)
        {
            todo.IsCompleted = !todo.IsCompleted;
            await Task.CompletedTask;

        }
    }
}
