namespace jira_.net_server.Services;

public class UserService : IUserService
{
    private readonly IDBUtils _utils;
    private readonly string TABLE_NAME = DBHelpers.GetTableName(ETableName.User);
    public UserService(IDBUtils utils)
    {
        _utils = utils;
    }

    public async Task<User?> GetAsync(string userId)
    {
        return await _utils.FindByIdAsync<User>(userId, TABLE_NAME);
    }

    public async Task<List<User>> GetMembersAsync()
    {
        var res = await _utils.FindAsync<User>(new Dictionary<string, object> { { "username", "John" } }, TABLE_NAME);
        return res;
    }
}
