using MongoDB.Driver;
using MongoDB.Bson;
using jira_.net_server.Data;

public class MongoDBUtils : IDBUtils
{
    private readonly MongoDBContext _database;

    public MongoDBUtils(MongoDBContext database)
    {
        _database = database;
    }

    public async Task CreateItemAsync<T>(T item, string tableName)
    {
        var collection = _database.GetCollection<T>(tableName);
        await collection.InsertOneAsync(item);
    }

    public async Task<T?> FindOneAsync<T>(Dictionary<string, object> reqBody, string tableName)
    {
        var collection = _database.GetCollection<T>(tableName);

        var filterBuilder = Builders<T>.Filter;
        var filters = new List<FilterDefinition<T>>();

        foreach (var keyValuePair in reqBody)
        {
            filters.Add(filterBuilder.Eq(keyValuePair.Key, keyValuePair.Value));
        }

        var filter = filterBuilder.And(filters);
        var result = await collection.Find(filter).ToListAsync();

        if (result.Count == 0)
        {
            return default(T); ;
        }
        else return result[0];
    }

    public async Task<List<T>> FindAsync<T>(Dictionary<string, object> reqBody, string tableName)
    {
        var collection = _database.GetCollection<T>(tableName);

        var filterBuilder = Builders<T>.Filter;
        var filters = new List<FilterDefinition<T>>();

        foreach (var keyValuePair in reqBody)
        {
            filters.Add(filterBuilder.Eq(keyValuePair.Key, keyValuePair.Value));
        }

        var filter = filterBuilder.And(filters);
        var result = await collection.Find(filter).ToListAsync();

        return result;
    }

    public async Task<T> FindByIdAsync<T>(string id, string tableName)
    {
        var collection = _database.GetCollection<T>(tableName);
        var filter = Builders<T>.Filter.Eq("_id", id);
        var result = await collection.Find(filter).FirstOrDefaultAsync();

        return result;
    }

    public async Task<T> FindByIdAndUpdateAsync<T>(string id, T update, string tableName)
    {
        if (update == null)
        {
            throw new ArgumentNullException(nameof(update));
        }
        var collection = _database.GetCollection<T>(tableName);
        var filter = Builders<T>.Filter.Eq("_id", id);

        var updateDefinition = Builders<T>.Update.Combine();
        var updateDocument = BsonDocument.Parse(update.ToJson());
        foreach (var element in updateDocument.Elements)
        {
            if (element.Name != "_id")
            {
                updateDefinition = updateDefinition.Set(element.Name, element.Value);
            }
        }

        var options = new FindOneAndUpdateOptions<T> { ReturnDocument = ReturnDocument.After };
        var result = await collection.FindOneAndUpdateAsync(filter, updateDefinition, options);

        return result;
    }

    public async Task<T> FindByIdAndDeleteAsync<T>(string id, string tableName)
    {
        var collection = _database.GetCollection<T>(tableName);

        var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
        var result = await collection.FindOneAndDeleteAsync(filter);

        return result;
    }


}