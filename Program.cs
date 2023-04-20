using DotNetEnv;

// Load environment variables from .env file
Env.Load();

// Create the web host builder
var builder = WebApplication.CreateBuilder(args);

// Register services
Service.Register(builder);

// Build the application
var app = builder.Build();

// Configure the middleware pipeline
Middleware.Configure(app, app.Environment.IsDevelopment());

app.Run();
