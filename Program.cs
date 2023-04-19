using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Set the database type based on the environment variable
builder.Configuration["DBType"] = Environment.GetEnvironmentVariable("DB_TYPE") == "PostgreSQL" ? "PostgreSQL" : "MongoDB";

// Register services
Service.Register(builder);

var app = builder.Build();

// Configure the middleware pipeline
Middleware.Configure(app, app.Environment.IsDevelopment());

app.Run();
