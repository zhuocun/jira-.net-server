namespace jira_.net_server.Services;

public class UserService : IUserService
{
    private readonly IDBUtils _utils;
    public UserService(DBUtilsFactory _factory)
    {
        _utils = _factory.GetDBUtils(EDBType.MongoDB);
    }

    public async Task<User> Get(string userId)
    {
        return await _utils.FindById<User>(userId, "users");
    }

    public async Task<List<User>> GetMembers()
    {
        var res = await _utils.Find<User>(new Dictionary<string, object> { { "username", "John" } }, "users");
        return res;
    }
}
