using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public string _id { get; set; } = null!;
    public string username { get; set; } = null!;
    public string password { get; set; } = null!;
    public string email { get; set; } = null!;
    public List<String> likedProjects { get; set; } = new List<String>();

}
