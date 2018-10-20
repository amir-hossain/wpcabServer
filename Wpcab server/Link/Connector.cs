using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WpcabServer.Data;
using WpcabServer.Model;

namespace WpcabServer.Link
{
   

    public class Connector :IConnector
    {
        private static Connector connector= new Connector();

        private static IMongoDatabase database = DBContext.getInstance();

        private static string UserCollection="user";

     
        public static Connector getInstance()
        {
            return connector;
        }



        public bool InsertUser(User user)
        {
            var result = database.GetCollection<User>(UserCollection).InsertOneAsync(user);

            result.Wait();

            if (result.IsCompleted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Response> FetchUser(int page)
        {
            List<User> users = null;
            var result = database.GetCollection<User>(UserCollection);
            if (page > 1)
            {
                users = await result.Find(new BsonDocument()).Skip(10).Limit(10).ToListAsync();
            }
            else
            {
                users = await result.Find(new BsonDocument()).Skip((page-1)*10).Limit(10).ToListAsync();
            }
           
        
            long total = await result.CountDocumentsAsync(x => true);

            return new Response(users,total);
        }

    }
}
