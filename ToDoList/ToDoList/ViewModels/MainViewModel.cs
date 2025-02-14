using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.ViewModels
{
    public class MainViewModel
    {
        private readonly TodoServiceInterface _todoService;
        public ObservableCollection<Todo> TodoItems {get;} = new ObservableCollection<Todo>();

        public MainViewModel(TodoServiceInterface todoService)
        {
            _todoService = todoService;
        }
        public async Task LoadTodoItemsAsync()
        {
            var todo = await _todoService.GetTodos();
            foreach (var item in todo)
            {
                TodoItems.Add(item);
            }
        }

        public async Task AddTodoItemAsync(string title)
        {
            var newTodoItem = new Todo { Title = title };
            await _todoService.AddTodoAsync(newTodoItem);
            TodoItems.Add(newTodoItem);
        }

        public async Task ToggleTodoItemCompletionAsync(Todo todo)
        {
            await _todoService.ToggleTodoCompleteAsync(todo);
        }
    }
}
