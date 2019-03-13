using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCandMongoDB.Models
{
    public class UserBSON
    {
        [BsonId]
        public ObjectId ID { get; set; }
        [BsonElement("Ime")]
        public string Ime { get; set; }
        [BsonElement("Prezime")]
        public string Prezime { get; set; }
        [BsonElement("Godine")]
        public int Godine { get; set; }
        [BsonElement("JMBG")]
        public string JMBG { get; set; }
        [BsonElement("Adresa")]
        public AdresaBSON Adresa { get; set; }
        [BsonElement("Grupe")]
        public BsonArray Grupe { get; set; }

    }
}