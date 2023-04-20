public interface IUserService
{
    Task<User?> GetAsync(string userId);
    Task<List<User>> GetMembersAsync();
}
