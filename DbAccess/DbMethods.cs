using MongoDB.Bson;
using MongoDB.Driver;
using WebApplication1.Models;
namespace WebApplication1.DbAccess;
    public class DbMethods
    {
       private const string connectionUri = "mongodb+srv://admin:root@practise.kxdj03i.mongodb.net/?retryWrites=true&w=majority";
       private const string dbName = "UserData";
       private const string userCollection = "Users";

    
        public IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
        var client = new MongoClient(connectionUri);
        var db = client.GetDatabase(dbName);
        return db.GetCollection<T>(collection);
        }
    public async Task<List<UserModel>> GetUserByID(int id)
    {
        var user = ConnectToMongo<UserModel>(dbName);
        var result = await user.FindAsync(u => u.Id.Equals(id));
        return result.ToList();
    }
    public async Task<List<UserModel>> GetUsers()
        {
            var user = ConnectToMongo<UserModel>(userCollection);
            var result = await user.FindAsync(_=>true);
            return result.ToList();
        }
    public async Task<bool> FindUserByEmail(string email,string password)
    {
        var collection = ConnectToMongo<UserModel>(userCollection);
        var result = await collection.FindAsync(us => us.Email.Equals(email) && us.Password.Equals(password));
        return result.Any() ? true : false;
    }
    public async Task<bool> FindUser(UserModel? user)
    {
        var collection = ConnectToMongo<UserModel>(userCollection);
        if (user != null)
        {
            var result = await collection.FindAsync(us => us.Email.Equals(user.Email) && us.Password.Equals(user.Password));
            return result.Any() ? true : false;
        }
       return false;

    }
    public  Task SaveUser(UserModel user)
    {
        var collection = ConnectToMongo<UserModel>(userCollection);
        return collection.InsertOneAsync(user);
    }

    }
//}
