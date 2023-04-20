using jira_.net_server.Data;
public class DBUtilsFactory
{
    public static IDBUtils? CreateDBUtils(WebApplicationBuilder builder)
    {
        string? dbType = Environment.GetEnvironmentVariable("DB_TYPE");
        if (dbType == null)
        {
            throw new Exception("Missing DB_TYPE environment variable");
        }
        switch (DBHelpers.GetDBType(dbType))
        {
            case EDBType.PostgreSQL:
                break;
            case EDBType.MongoDB:
                string? mongoDbConnectionString = builder.Configuration["MONGODB_CONNECTION_STRING"];
                string? databaseName = builder.Configuration["MONGODB_DATABASE_NAME"];
                if (mongoDbConnectionString == null || databaseName == null)
                {
                    throw new Exception("Missing MongoDB connection string or database name");
                }
                builder.Services.AddSingleton<MongoDBContext>(sp => new MongoDBContext(mongoDbConnectionString, databaseName));
                MongoDBContext? context = builder.Services.BuildServiceProvider().GetService<MongoDBContext>();
                if (context == null)
                {
                    throw new Exception("Failed to create MongoDB context");
                }
                Console.WriteLine($"Connect to {dbType} successfully");
                return new MongoDBUtils(context);
            default:
                throw new Exception("Invalid database type specified in configuration");
        }

        return null;
    }
}

