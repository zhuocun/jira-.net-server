using Newtonsoft.Json.Linq;

namespace jira_.net_server.Utils.Database;

public class DBOperation
{
    private readonly IDBUtils _dbUtils;

    public DBOperation(IDBUtils dbUtils)
    {
        _dbUtils = dbUtils;
    }

    public Task<JObject?> FindOneAsync(Dictionary<string, object> reqBody, string tableName)
    {
        return _dbUtils.FindOneAsync<JObject>(reqBody, tableName);
    }

    public Task CreateItemAsync<T>(T item, string tableName)
    {
        return _dbUtils.CreateItemAsync(item, tableName);
    }

    public Task<List<JObject>> FindAsync(Dictionary<string, object> reqBody, string tableName)
    {
        return _dbUtils.FindAsync<JObject>(reqBody, tableName);
    }

    public Task<JObject?> FindByIdAsync(string id, string tableName)
    {
        return _dbUtils.FindByIdAsync<JObject>(id, tableName);
    }

    public Task<JObject> FindByIdAndDeleteAsync(string id, string tableName)
    {
        return _dbUtils.FindByIdAndDeleteAsync<JObject>(id, tableName);
    }

    public Task<JObject> FindByIdAndUpdateAsync(string id, JObject update, string tableName)
    {
        return _dbUtils.FindByIdAndUpdateAsync<JObject>(id, update, tableName);
    }
}

