using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCandMongoDB.Models
{
    public class ProductBSON
    {
        [BsonId]
        public ObjectId ID { get; set; }
        [BsonElement("Naziv")]
        public string Naziv { get; set; }
        [BsonElement("Cena")]
        public BsonDouble Cena { get; set; }
        [BsonElement("NaStanju")]
        public BsonBoolean NaStanju { get; set; }
    }
}