using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisCacheDAL
{
    public class ReaderDAL
    {
        string Host;
        int Port;
        public ReaderDAL(string host, int port)
        {
            Host = host;
            Port = port;
        }
        public long CheckExisting(string key)
        {
            long exists = 0;
            using (RedisClient redisClient = new RedisClient(Host, Port))
            {
                exists = redisClient.Exists(key);
            }
            return exists;
        }
        public string GetValue(string key)
        {
            if (CheckExisting(key) == 1)
            {
                using (RedisClient redisClient = new RedisClient(Host, Port))
                {
                    return redisClient.Get<string>(key);
                }
            }
            return "this key doesn't exist";
        }
        public List<string> GetList(string key)
        {
            List<string> strings = new List<string>();
            if (CheckExisting(key) == 1)
            {
                using (RedisClient redisClient = new RedisClient(Host, Port))
                {
                    long count = redisClient.LLen(key);
                    for(int i = 0; i < count; i++)
                    {
                        strings.Add(Encoding.UTF8.GetString(redisClient.LIndex(key, i)));
                    }
                }
                return strings;
            }
            strings.Add("this key doesn't exist");
            return strings;
        }
    }
}
