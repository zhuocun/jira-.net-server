using jira_.net_server.Data;
using jira_.net_server.Services;

public static class Service
{
    public static void RegisterServices(WebApplicationBuilder builder)
    {
        var mongoDbConnectionString = builder.Configuration["MONGODB_CONNECTION_STRING"];
        var databaseName = builder.Configuration["MONGODB_DATABASE_NAME"];
        if (mongoDbConnectionString == null || databaseName == null)
        {
            throw new Exception("Missing MongoDB connection string or database name");
        }
        builder.Services.AddControllers();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddSingleton<MongoDBContext>(sp => new MongoDBContext(mongoDbConnectionString, databaseName));
        builder.Services.AddSingleton<DBUtilsFactory>();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }
}
