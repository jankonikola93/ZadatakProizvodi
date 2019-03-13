using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCandMongoDB.Models.ViewModels
{
    public class ProductViewModel
    {
        public string ID { get; set; }
        public string Naziv { get; set; }
        public double Cena { get; set; }
        public bool NaStanju { get; set; }
    }
}