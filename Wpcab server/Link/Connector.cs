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

        private static string collectionName="user";

     
        public static Connector getInstance()
        {
            return connector;
        }



        public bool InsertUser(User user)
        {
            var result = database.GetCollection<User>(collectionName).InsertOneAsync(user);

            result.Wait();

            if (result.IsCompletedSuccessfully)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditUser(User user)
        {
            
            var db = database.GetCollection<User>(collectionName);

            var filer = Builders<User>.Filter.Eq(u => u.ID,user.ID);

            var result=db.ReplaceOneAsync(filer, user);

            result.Wait();

            if (result.IsCompletedSuccessfully)
            {
                return true;

            }
            else
            {
                return false;
            }

 
        }

        public async Task<Response> GetUsersByPage(int page)
        {
            List<User> users = null;
            var result = database.GetCollection<User>(collectionName);
            if (page > 1)
            {
                users = await result.Find(new BsonDocument()).Skip((page - 1) * 10).Limit(10).ToListAsync();
            }
            else
            {
                users = await result.Find(new BsonDocument()).Limit(10).ToListAsync();
                
            }
           
        
            long total = await result.CountDocumentsAsync(x => true);

            return new Response(users,total);
        }

        public User GetUserById(string id)
        {
            var result = database.GetCollection<User>(collectionName);

            return result.Find(k => k.ID.Equals(id)).FirstOrDefault();

        }


    }
}
