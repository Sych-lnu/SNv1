using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNv1
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        private ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> Interests { get; set; }
        public List<string> Friends { get; set; }
        public List<Post> Posts { get; set; }
        public User(string firstname, string lastname, string email, string password, List<string> interests, List<string> friends, List<Post> posts)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Password = password;
            Interests = interests;
            Friends = friends;
            Posts = posts;
        }
        public User()
        {
            FirstName = "firstname";
            LastName = "lastname";
            Interests = new List<string>();
            Friends = new List<string>();
            Posts = new List<Post>();
            Email = "default@gmail.com";
            Password = "defaultPass";
        }
    }
}
