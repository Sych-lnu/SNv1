using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNv1
{
    public class Post
    {
        public string Content { get; set; }
        public string Author { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Reaction> Reactions { get; set; }
        public DateTime CreateTime { get; set; }
        public Post(string content, string author, List<Reaction> reactions, List<Comment> comments, DateTime createTime)
        {
            Content = content;
            Author = author;
            Reactions = reactions;
            Comments = comments;
            CreateTime = createTime;
        }
        public Post()
        {
            Content = "default";
            Author = "default@gmail.com";
            Reactions = new List<Reaction>();
            Reactions.Add(new Reaction("like", 0));
            Reactions.Add(new Reaction("cool", 0));
            Reactions.Add(new Reaction("dislike", 0));
            Comments = new List<Comment>();
            CreateTime = DateTime.Now;
        }
        public Post(string content, string author)
        {
            Content = content;
            Author= author;
            Reactions = new List<Reaction>();
            Reactions.Add(new Reaction("like", 0));
            Reactions.Add(new Reaction("cool", 0));
            Reactions.Add(new Reaction("dislike", 0));
            Comments = new List<Comment>();
            CreateTime = DateTime.Now;
        }
    }
}
