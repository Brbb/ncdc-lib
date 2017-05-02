using System;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;

namespace NCDCLib.Database
{
    public class NCDCDbManager
    {
        public static NCDCDbManager _instance;
        protected static IMongoClient _mongoClient;
        protected static IMongoDatabase _mongoDb;


        NCDCDbManager()
        {
            _mongoClient = new MongoClient();
            _mongoDb = _mongoClient.GetDatabase("ncdcdb");
            var commandAsync = _mongoDb.RunCommandAsync((Command<BsonDocument>)"{ping:1}");
            var pingResult = commandAsync.Result;
            if (pingResult.Names.FirstOrDefault() != "ok")
                throw new Exception("Mongodb server or database not reachable or running");

        }

        public static NCDCDbManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NCDCDbManager();
                }

                return _instance;
            }
        }


    }
}