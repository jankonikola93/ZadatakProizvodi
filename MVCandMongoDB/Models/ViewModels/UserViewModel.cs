using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCandMongoDB.Models.ViewModels
{
    public class UserViewModel
    {
        public string ID { get; set; }
        
        public string Ime { get; set; }
        
        public string Prezime { get; set; }
        
        public int Godine { get; set; }
        
        public string JMBG { get; set; }

        public AdresaViewModel Adresa { get; set; }

        public BsonArray Grupe { get; set; }

    }
}