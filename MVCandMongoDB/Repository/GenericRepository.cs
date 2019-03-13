using MongoDB.Bson;
using MongoDB.Driver;
using MVCandMongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace MVCandMongoDB.Repository
{
    public class GenericRepository<TDocument> : IGenericReposiroty<TDocument> where TDocument : class
    {
        private MongoDbContext context;
        private string collectionName;
        private IMongoCollection<TDocument> collection;
        public GenericRepository(string collectionName)
        {
            this.context = new MongoDbContext();
            this.collectionName = collectionName;
            this.collection = context.mongoDatabase.GetCollection<TDocument>(collectionName);
        }

        public IEnumerable<TDocument> GetAll()
        {
            var documents = collection.Find(new BsonDocument()).ToList();
            return documents;
        }

        public void Insert(TDocument document)
        {
            collection.InsertOne(document);
        }

        public void Update(TDocument document, Expression<Func<TDocument, bool>> filter)
        {
            collection.ReplaceOne(filter, document);
        }

        public void Delete(Expression<Func<TDocument, bool>> filter)
        {
            collection.DeleteOne(filter);
        }

        public IEnumerable<TDocument> Find(Expression<Func<TDocument, bool>> filter)
        {
            var documents = collection.Find(filter).ToList();
            return documents;
        }

        public TDocument FindOne(Expression<Func<TDocument, bool>> filter)
        {
            var document = collection.Find(filter).FirstOrDefault();
            return document;
        }

        public void InsertMany(IEnumerable<TDocument> documents)
        {
            collection.InsertMany(documents);
        }

        public void UpdateMany(IEnumerable<TDocument> documents, Expression<Func<TDocument, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void DeleteMany(Expression<Func<TDocument, bool>> filter)
        {
            collection.DeleteMany(filter);
        }
    }
}