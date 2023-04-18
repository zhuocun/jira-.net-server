public interface IUserService
{
    // Define the methods your service will implement
    User GetUser(int userId);
    IEnumerable<User> GetAllUsers();
    // Add other methods as needed
}
