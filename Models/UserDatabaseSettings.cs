namespace WebApplication1.Models
{
    public class UserDatabaseSettings: IUserDatabaseSettings
    {
       public string UserName { get; set; }
      public  string Email { get; set; }
       public string Password { get; set; }
    }
    public interface IUserDatabaseSettings
    {
        string UserName { get; set; }
        string Password { get; set; }
        string Email { get; set; }
    }
}

