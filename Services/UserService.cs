namespace jira_.net_server.Services;

public class UserService : IUserService
{
    private readonly IDBUtils _utils;
    public UserService(DBUtilsFactory _factory)
    {
        _utils = _factory.GetDBUtils(EDBType.MongoDB);
    }

    public async Task<User> GetAsync(string userId)
    {
        return await _utils.FindByIdAsync<User>(userId, "users");
    }

    public async Task<List<User>> GetMembersAsync()
    {
        var res = await _utils.FindAsync<User>(new Dictionary<string, object> { { "username", "John" } }, "users");
        return res;
    }
}
