using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCandMongoDB.Models.ViewModels
{
    public class OrderViewModel
    {
        public string _id { get; set; }
        
        public string Product_ID { get; set; }
        
        public string User_ID { get; set; }
       
        public int Kolicina { get; set; }
        
        public double UkupnaCena { get; set; }

        public bool Placeno { get; set; }
        public bool Isporuceno { get; set; }
    }
}