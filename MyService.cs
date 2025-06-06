// Create the class that implements the interface.
// <summary>
// MyService class that implements IMyService interface.
// </summary>
// This class will be registered with the dependency injection container and can be injected into controllers or other services.
// It contains a method to log the creation of the service with a unique ID.
// The service ID is generated randomly when the service is created.
// The LogCreation method logs a message along with the service ID to the console.
// This allows tracking of service creation and can be useful for debugging or logging purposes.
using System;
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