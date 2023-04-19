
public interface IUserService
{
    // Define the methods your service will implement
    Task<User> Get(string userId);
    Task<List<User>> GetMembers();

}
