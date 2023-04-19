using Newtonsoft.Json.Linq;

namespace jira_.net_server.Utils.Database
{
    public class DBOperation
    {
        private readonly IDBUtils _dbUtils;

        public DBOperation(IDBUtils dbUtils)
        {
            _dbUtils = dbUtils;
        }

        public Task<JObject?> FindOne(Dictionary<string, object> reqBody, string tableName)
        {
            return _dbUtils.FindOne<JObject>(reqBody, tableName);
        }

        public Task CreateItem<T>(T item, string tableName)
        {
            return _dbUtils.CreateItem(item, tableName);
        }

        public Task<List<JObject>> Find(Dictionary<string, object> reqBody, string tableName)
        {
            return _dbUtils.Find<JObject>(reqBody, tableName);
        }

        public Task<JObject> FindById(string id, string tableName)
        {
            return _dbUtils.FindById<JObject>(id, tableName);
        }

        public Task<JObject> FindByIdAndDelete(string id, string tableName)
        {
            return _dbUtils.FindByIdAndDelete<JObject>(id, tableName);
        }

        public Task<JObject> FindByIdAndUpdate(string id, JObject update, string tableName)
        {
            return _dbUtils.FindByIdAndUpdate<JObject>(id, update, tableName);
        }
    }
}
