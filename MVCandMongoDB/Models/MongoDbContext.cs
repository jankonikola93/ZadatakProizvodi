using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCandMongoDB.Models
{
    public class MongoDbContext
    {
        private IMongoClient mongoClient;
        public readonly IMongoDatabase mongoDatabase;
        public MongoDbContext()
        {
            this.mongoClient = new MongoClient("mongodb://localhost:27017");
            this.mongoDatabase = mongoClient.GetDatabase("MyDb");
        }
    }
}