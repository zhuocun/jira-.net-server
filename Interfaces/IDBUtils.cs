public interface IDBUtils
{
    Task<T?> FindOneAsync<T>(Dictionary<string, object> reqBody, string tableName);
    Task CreateItemAsync<T>(T item, string tableName);
    Task<List<T>> FindAsync<T>(Dictionary<string, object> reqBody, string tableName);
    Task<T?> FindByIdAsync<T>(string id, string tableName);
    Task<T> FindByIdAndDeleteAsync<T>(string id, string tableName);
    Task<T> FindByIdAndUpdateAsync<T>(string id, T update, string tableName);
}
