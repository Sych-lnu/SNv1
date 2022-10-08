using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


namespace SNv1
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            
            var client = new MongoClient("mongodb+srv://OleksandrSych:Ababagalamaga1977@socialnetwork.n4iabj4.mongodb.net/test");
            var database = client.GetDatabase("sn");
            var usersCollection = database.GetCollection<User>("posts");
            var projectionDefinition = Builders<User>.Projection.Include("Posts");
            var projectionResult = usersCollection.Find(Builders<User>.Filter.Empty).Project<User>(projectionDefinition).ToList();
            //Console.WriteLine(projectionResult[0].ToJson());

            Console.WriteLine(projectionResult[0].Posts.ToJson());
            //


            Console.WriteLine("Done");
            //
            Console.ReadLine();
        }
    }
}
