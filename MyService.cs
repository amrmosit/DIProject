// Create the class that implements the interface.
public class MyService : IMyService
{
    private readonly int _serviceId;
    public MyService()
    {
        _serviceId = new Random().Next(100000, 999999);
    }
    public void LogCreation(string message)
    {
        Console.WriteLine($"Service ID: {_serviceId}, Message: {message}");
    }
}