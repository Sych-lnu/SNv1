using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNv1
{
    public class Comment
    {
        public string Content { get; set; }
        public string Author { get; set; }
        public List<Reaction> Reactions { get; set; }
        public DateTime CreateTime { get; set; }

        public Comment(string content, string author, List<Reaction> reactions, DateTime createTime)
        {
            Content = content;
            Author = author;
            Reactions = reactions;
            CreateTime = createTime;
        }
        public Comment(string content, string author)
        {
            Content = content;
            Author= author;
            Reactions = new List<Reaction>();
            Reactions.Add(new Reaction("like", 0));
            Reactions.Add(new Reaction("cool", 0));
            Reactions.Add(new Reaction("dislike", 0));
            CreateTime = DateTime.Now;
        }
        public Comment(string content)
        {
            Content = content;
            Reactions = new List<Reaction>();
            Reactions.Add(new Reaction("like", 0));
            Reactions.Add(new Reaction("cool", 0));
            Reactions.Add(new Reaction("dislike", 0));
            CreateTime = DateTime.Now;
        }
        public Comment()
        {
            Content = "default";
            Author = "default@gmail.com";
            Reactions = new List<Reaction>();
            Reactions.Add(new Reaction("like", 0));
            Reactions.Add(new Reaction("cool", 0));
            Reactions.Add(new Reaction("dislike", 0));
            CreateTime = DateTime.Now;
        }
    }
}
