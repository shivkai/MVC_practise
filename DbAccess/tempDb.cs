using MongoDB.Driver;
using System.Xml.Linq;
using WebApplication1.Models;

namespace WebApplication1.DbAccess
{
    class temp
    {
        public static List<UserModel> GetUsers()
        {
            var users = new List<UserModel>()
            {
                new UserModel(){Id="1",Email="shiv@gmail.com",Password="hello",Firstname="Shiv",Lastname="sharma"}
            };
            return users;

        }
    }
    public class tempDb
    {
        public  List<UserModel> GetUserByID(string id)
        {
            var user = temp.GetUsers().ToList();
            if (user != null && id == user[0].Id)
            {

                return user;
            }
            return new List<UserModel>() { };
            

            
        }
     
        public  bool FindUserByEmail(string email, string password)
        {
            var user = temp.GetUsers().ToList();

            if (user != null && email.Equals(user[0].Email) && password.Equals(user[0].Password))
            {

                return true;
            }
            return false;
        }
        public  bool FindUser(UserModel? user)
        {
            var users = temp.GetUsers().ToList();
            if (users != null && user.Id == users[0].Id && user.Password== users[0].Password)
            {

                return true;
            }
            return false;

        }
        public Task SaveUser(UserModel user)
        {
           return Task.CompletedTask;
        }
    }
}
