// To create a custom service, need to create an interface and a class that implements it.
// This interface will define the contract for the service, and the class will provide the implementation.
// The service can then be registered with the dependency injection container in the Program.cs file.
// This allows the service to be injected into controllers or other services later.
// The service can have different lifetimes, such as singleton, scoped, or transient, depending on the requirements of the application.
// The service can be used to log messages or perform other tasks as needed in the application.
public interface IMyService
{
    void LogCreation(string Message);
}