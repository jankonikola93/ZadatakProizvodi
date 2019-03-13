using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCandMongoDB.Models
{
    public class AdresaBSON
    {
        [BsonElement("Mesto")]
        public string Mesto { get; set; }
        [BsonElement("Ulica")]
        public string Ulica { get; set; }
        [BsonElement("Broj")]
        public int Broj { get; set; }
        [BsonElement("ZIP")]
        public string ZIP { get; set; }
    }
}