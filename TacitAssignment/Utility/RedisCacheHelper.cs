using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using StackExchange.Redis;
using System.Configuration;

namespace TacitAssignment.Utility
{
    public static class RedisCacheHelper
    {
        public static T Get<T>(string cacheKey)
        {
            return Deserialize<T>(GetDatabase().StringGet(cacheKey));
        }

        public static object Get(string cacheKey)
        {
            return Deserialize<object>(GetDatabase().StringGet(cacheKey));
        }

        public static void Remove(string cacheKey)
        {
            GetDatabase().KeyDelete(cacheKey);
        }

        public static void Set(string cacheKey, object cacheValue)
        {
            GetDatabase().StringSet(cacheKey, Serialize(cacheValue));
        }

        private static byte[] Serialize(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            BinaryFormatter objBinaryFormatter = new BinaryFormatter();
            using (MemoryStream objMemoryStream = new MemoryStream())
            {
                objBinaryFormatter.Serialize(objMemoryStream, obj);
                byte[] objDataAsByte = objMemoryStream.ToArray();
                return objDataAsByte;
            }
        }

        private static T Deserialize<T>(byte[] bytes)
        {
            BinaryFormatter objBinaryFormatter = new BinaryFormatter();
            if (bytes == null)
                return default(T);

            using (MemoryStream objMemoryStream = new MemoryStream(bytes))
            {
                T result = (T)objBinaryFormatter.Deserialize(objMemoryStream);
                return result;
            }
        }

        public static IDatabase GetDatabase()
        {
            IDatabase databaseReturn = null;
            
            var connectionMultiplexer = ConnectionMultiplexer.Connect(ConfigurationManager.AppSettings["RedisConnection"]);
            if (connectionMultiplexer.IsConnected)
                databaseReturn = connectionMultiplexer.GetDatabase();

            return databaseReturn;
        }
    }
}