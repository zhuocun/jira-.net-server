using jira_.net_server.Data;

public class DBUtilsFactory
{
    private readonly MongoDBContext _mongoDbContext;

    public DBUtilsFactory(MongoDBContext mongoDbContext)
    {
        _mongoDbContext = mongoDbContext;
    }

    public IDBUtils GetDBUtils(EDBType dbType)
    {
        return dbType switch
        {
            EDBType.MongoDB => new MongoDBUtils(_mongoDbContext),
            _ => throw new ArgumentOutOfRangeException(nameof(dbType), $"Invalid db type: {dbType}"),
        };
    }
}
