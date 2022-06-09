using Microsoft.AspNetCore.Mvc;
using webapi.Services;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    private readonly IHelloWorldService helloWorldService;
    private readonly TareaContext dbcontext;

    private readonly ILogger<WeatherForecastController> _logger;

    public HelloWorldController(IHelloWorldService helloWorldService, 
        ILogger<WeatherForecastController> logger,
        TareaContext dbcontext)
    {
        this._logger = logger;
        this.helloWorldService = helloWorldService;
        this.dbcontext = dbcontext;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Retornando hello!");
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbcontext.Database.EnsureCreated();

        return Ok();
    }
}