using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WpcabServer.Data
{
    public class DBContext
    {
        private IMongoClient _mongoClient;

        private IMongoDatabase _mongoDatabase;

        private string DBName = "wpcab_DB";

        private static string connectionString = "mongodb://wpcab:wpcab@localhost:27017/wpcab_DB";

        private static DBContext instance = new DBContext();

        private DBContext()
        {
            _mongoClient = new MongoClient(connectionString);
            _mongoDatabase = _mongoClient.GetDatabase(DBName);
     
            
        }

        public  static IMongoDatabase getInstance()
        {
            return instance._mongoDatabase;
        }
    }
}
