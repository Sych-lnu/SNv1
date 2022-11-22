using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisCacheDAL
{
    public class WriterDAL
    {
        string Host;
        int Port;
        public WriterDAL(string host, int post)
        {
            Host = host;
            Port = post;
        }
        public bool SaveValue(string key, string value)
        {
            bool isSuccess = false;
            using (RedisClient redisClient = new RedisClient(Host, Port))
            {
                isSuccess = redisClient.Set(key, value);
                redisClient.Expire(key, 15);
                return isSuccess;
            }
        }
        public void SaveToList(string key, string value)
        {
            using (RedisClient redisClient = new RedisClient(Host, Port))
            {
                redisClient.RPush(key, Encoding.UTF8.GetBytes(value));
                redisClient.Expire(key, 15);
            }

        }
        public void SaveList(string key, List<string> values)
        {
            using (RedisClient redisClient = new RedisClient(Host, Port))
            {
                foreach (string value in values)
                {
                    redisClient.RPush(key, Encoding.UTF8.GetBytes(value));
                }
                redisClient.Expire(key, 15);
            }
        }

    }
}
