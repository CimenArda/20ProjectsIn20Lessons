using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbOrderProjecet.Services
{
    public class MongoDbConnection
    {
        private IMongoDatabase _mongoDatabase;

        public MongoDbConnection()
        {
            var client = new MongoClient("mongodb://localhost:27017/");
            _mongoDatabase = client.GetDatabase("DbOrderProject");
        }

        public IMongoCollection<BsonDocument> GetOrdersCollection()
        {
            return _mongoDatabase.GetCollection<BsonDocument>("Orders");
        }



    }
}
