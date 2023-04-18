namespace jira_.net_server.Services;

public class UserService : IUserService
{
    public User GetUser(int userId)
    {
        return new User(userId, "John", "Doe", "   ");
    }

    public IEnumerable<User> GetAllUsers()
    {
        return new List<User>
        {
            new User(1, "John", "Doe", "   "),
            new User(2, "Jane", "Doe", "   ")
        };
    }

}
