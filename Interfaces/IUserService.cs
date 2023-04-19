public interface IUserService
{
    Task<User> Get(string userId);
    Task<List<User>> GetMembers();
}
