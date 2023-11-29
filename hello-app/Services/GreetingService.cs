namespace hello_app.Services;


public class GreetingService : IGreetingService
{
    public string GreetingWithName(string name)
    {
        // Вынести шаблон в property файл?
        return $"Hello, {name}";
    }
}