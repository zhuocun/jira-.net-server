using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public string _id { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public List<String> likedProjects { get; set; }

    public User(string id, string username, string password, string email)
    {
        this._id = id;
        this.username = username;
        this.password = password;
        this.email = email;
        this.likedProjects = new List<String>();
    }
}
