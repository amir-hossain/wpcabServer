﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WpcabServer.Data;
using WpcabServer.Model;

namespace WpcabServer.Link
{
    public class Connector
    {
        private static IMongoDatabase database = DBContext.getInstance();

        private static string UserCollection="user";

        public static bool InsertUser(User user)
        {

            var result=database.GetCollection<User>(UserCollection).InsertOneAsync(user);

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

        
    }
}
