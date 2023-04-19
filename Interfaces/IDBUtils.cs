public interface IDBUtils
{
    Task<T?> FindOne<T>(Dictionary<string, object> reqBody, string tableName);
    Task CreateItem<T>(T item, string tableName);
    Task<List<T>> Find<T>(Dictionary<string, object> reqBody, string tableName);
    Task<T> FindById<T>(string id, string tableName);
    Task<T> FindByIdAndDelete<T>(string id, string tableName);
    Task<T> FindByIdAndUpdate<T>(string id, T update, string tableName);
}
