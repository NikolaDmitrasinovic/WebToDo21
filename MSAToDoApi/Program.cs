var builder = WebApplication.CreateBuilder(args);

// Add DI - AddService

var app = builder.Build();

// Configure pipeline - UseMethod...

app.Run();
