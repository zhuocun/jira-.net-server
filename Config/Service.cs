using jira_.net_server.Data;
using jira_.net_server.Services;

public static class Service
{
    public static void Register(WebApplicationBuilder builder)
    {
        IDBUtils? dbUtils = DBUtilsFactory.CreateDBUtils(builder);
        if (dbUtils == null)
        {
            throw new Exception("Failed to create DBUtils");
        }
        builder.Services.AddSingleton<IDBUtils>(sp => dbUtils);
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }
}
