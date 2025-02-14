using ToDoList.Models;
using ToDoList.Services;
using ToDoList.ViewModels;

namespace ToDoList.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel _viewModel;
        public MainPage()
        {
            InitializeComponent();
            _viewModel = new MainViewModel(new TodoService());
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadTodoItemsAsync();
        }

        private async void OnAddTodoClicked(object sender, EventArgs e)
        {
            var newTodoTitle = NewTodoEntry.Text;
            if (!string.IsNullOrWhiteSpace(newTodoTitle)) { 
            await _viewModel.AddTodoItemAsync(newTodoTitle);
                NewTodoEntry.Text = string.Empty;
            }
        }

        private async void OnTodoItemToggled(object sender, EventArgs e)
        {
            if (sender is Switch toggleSwitch && toggleSwitch.BindingContext is Todo todo)
            {
                await _viewModel.ToggleTodoItemCompletionAsync(todo);
            }
        }
    }
}