using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCandMongoDB.Models
{
    public class OrderBSON
    {
        [BsonId]
        public ObjectId _id { get; set; }
        [BsonElement("Product_ID")]
        public ObjectId Product_ID { get; set; }
        [BsonElement("User_ID")]
        public ObjectId User_ID { get; set; }
        [BsonElement("Kolicina")]
        public BsonInt32 Kolicina { get; set; }
        [BsonElement("UkupnaCena")]
        public BsonDouble UkupnaCena { get; set; }
        [BsonElement("Placeno")]
        public BsonBoolean Placeno { get; set; }
        [BsonElement("Isporuceno")]
        public BsonBoolean Isporuceno { get; set; } 
    }
}