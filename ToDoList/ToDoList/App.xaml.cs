using ToDoList.Services;
namespace ToDoList
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddScoped<TodoServiceInterface, TodoService>();
            var app = builder.Build();
            app.Services.GetService<TodoServiceInterface>();
            MainPage = new AppShell();
        }
    }
}
