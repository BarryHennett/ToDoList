using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Services
{
    public interface TodoServiceInterface
    {
        Task<List<Todo>> GetTodos();
        Task AddTodoAsync(Todo todo); //add items
        Task ToggleTodoCompleteAsync(Todo todo); //toggle on and off
    }
}
