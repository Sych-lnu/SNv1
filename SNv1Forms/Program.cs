using MongoDB.Bson;
using MongoDB.Driver;
using ServiceStack;
using SNv1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNv1Forms
{
    public static class Program
    {

        public static MongoClient client = new MongoClient("mongodb+srv://OleksandrSych:Ababagalamaga1977@socialnetwork.n4iabj4.mongodb.net/test");
        public static IMongoDatabase database = client.GetDatabase("sn");
        public static User currentUser;
        public static string host = "127.0.0.1";
        public static int port = 6379; 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static void LogIn(string email, string password)
        {
            IMongoCollection<User> usersCollection = database.GetCollection<User>("posts");
            var projectionDefinition = Builders<User>.Filter;
            var filter = projectionDefinition.Eq("Email", email);
            var logUsers = usersCollection.Find(filter).ToList();
            if (logUsers.Count!=0)
            {
                var logged = logUsers[0];
                if (logged.Password == password)
                {
                    currentUser = logged;
                }
            }
        }
    }
}
