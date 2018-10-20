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


        private  string getNextId(List<User> users)
        {
            string nextId = null;
            if (users.Count > 10)
            {
                nextId = users[10].ID;
            }

            return nextId;
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

        public async Task<Response> FetchUser()
        {
            var result = database.GetCollection<User>(UserCollection);
            //var cursor = await result.FindAsync(new BsonDocument());
            var cursor = result.Find(new BsonDocument()).Limit(11);
            List<User> users = await cursor.ToListAsync();
            string nextId = getNextId(users);
            long total = await result.CountDocumentsAsync(x => true);

            return new Response(users, nextId, total);
        }
    }
}
