var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Adding a custom service to the dependency injection container
// This service can be injected into controllers or other services later.
//Creating an instance of the service and registering it with the DI container
// This allows the service to be injected wherever needed in the application.

// There are three main lifetimes for services in ASP.NET Core:
/* Registering services with different lifetime*/

// 1. Singleton: A single instance is created and shared throughout the application lifetime.
// AddSingleton means that a single instance of the service will be created and shared throughout the application lifetime.
builder.Services.AddSingleton<IMyService, MyService>();

// 2. Scoped: A new instance is created for each request.
// AddScoped means that a new instance of the service will be created for each request
//builder.Services.AddScoped<IMyService, MyService>();

// 3. Transient: A new instance is created each time it is requested.
// AddTransient means that a new instance of the service will be created each time it is requested
//builder.Services.AddTransient<IMyService, MyService>();

var app = builder.Build();

// Adding Middleware
app.Use(async (context, next) =>
{
    var myService = context.RequestServices.GetRequiredService<IMyService>();
    myService.LogCreation("First Middleware is processing the request.");
    await next();
});
app.Use(async(context, next) =>
{
    var myService = context.RequestServices.GetRequiredService<IMyService>();
    myService.LogCreation("Second Middleware is processing the request.");
    await next();
});

app.MapGet("/", (IMyService myService) =>
{
    myService.LogCreation("Hello, World!");
    return Results.Ok("Check the console for service creation log.");
});
app.MapGet("/home", () => "This is the home page!");

app.Run();