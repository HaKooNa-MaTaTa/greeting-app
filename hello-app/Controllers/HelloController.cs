using hello_app.Services;
using Microsoft.AspNetCore.Mvc;

namespace hello_app.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{

    private readonly IGreetingService _greetingService;
    
    public HelloController(IGreetingService greetingService)
    {
        _greetingService = greetingService;
    }

    [HttpPost]
    public string Greeting(string name)
    {
        return _greetingService.GreetingWithName(name);
    }

}