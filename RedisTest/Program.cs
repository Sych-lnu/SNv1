using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;
using RedisCacheDAL;
using SNv1;
using MongoDB.Driver;
using MongoDB.Bson;

namespace RedisTest
{
    internal class Program
    {
        public static MongoClient client = new MongoClient("mongodb+srv://OleksandrSych:Ababagalamaga1977@socialnetwork.n4iabj4.mongodb.net/test");
        public static IMongoDatabase database = client.GetDatabase("sn");
        static void Main(string[] args)
        {
            string host =  "127.0.0.1";
            int port =  6379;
            WriterDAL writer = new WriterDAL(host, port);
            ReaderDAL reader = new ReaderDAL(host, port);
            /*
            WriterDAL writer = new WriterDAL(host, port);
            ReaderDAL reader = new ReaderDAL(host, port);
            writer.SaveValue("testkey", "testvalue");
            Console.WriteLine(reader.GetValue("testkey"));
            writer.SaveValue("testkey", "testvalue-updated");
            Console.WriteLine(reader.GetValue("testkey"));
            Console.ReadLine();
            
            List<string> strings = new List<string>();
            strings.Add("test-1");
            strings.Add("test-2");
            //writer.SaveList("testlist", strings);
            var newList = reader.GetList("testlist");
            foreach (string s in newList)
            {
                Console.WriteLine(s);
            }
            */
            var usersCollection = Program.database.GetCollection<User>("posts");
            var postsDefinition = Builders<User>.Projection.Include("Posts");
            var postsResult = usersCollection.Find(Builders<User>.Filter.Empty).Project<User>(postsDefinition).ToList();
            var allPosts = postsResult[0].Posts;
            for (int i = 1; i < postsResult.Count; i++)
            {
                for (int j = 0; j < postsResult[i].Posts.Count; j++)
                {
                    allPosts.Add(postsResult[i].Posts[j]);
                }
            }
            Sort(allPosts);
            List<string> contents = new List<string>();
            List<string> authors = new List<string>();
            foreach(var post in allPosts)
            {
                authors.Add(post.Author);
                contents.Add(post.Content);
            }
            writer.SaveList("authors", authors);
            writer.SaveList("contents", contents);
            List<string> postInfo = new List<string>();
            for(int i = 0; i < reader.GetList("authors").Count; i++)
            {
                postInfo.Add(reader.GetList("authors")[i] + ": " + reader.GetList("contents")[i]);
            }
            Console.WriteLine("real posts:");
            for (int i = 0; i < allPosts.Count(); i++)
            {
                string itemText = allPosts[i].Author + ": " + allPosts[i].Content;
                Console.WriteLine(itemText);
            }
            Console.WriteLine("Cached posts:");
            for(int i = 0; i < postInfo.Count; i++)
            {
                Console.WriteLine(postInfo[i]);
            }
            Console.ReadLine();
        }
        public static void Sort(List<Post> posts)
        {
            for (int i = 0; i < posts.Count; i++)
            {
                for (int j = i + 1; j < posts.Count; j++)
                {
                    if (posts[i].CreateTime < posts[j].CreateTime)
                    {
                        var temp = posts[i];

                        posts[i] = posts[j];

                        posts[j] = temp;
                    }
                }
            }
        }


    }
}
