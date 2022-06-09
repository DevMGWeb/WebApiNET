namespace webapi.Services;

public class HelloWorldService : IHelloWorldService
{
    public string GetHelloWorld()
    {
        return "Hello World";
    }
}

public interface IHelloWorldService
{
    public string GetHelloWorld();
}