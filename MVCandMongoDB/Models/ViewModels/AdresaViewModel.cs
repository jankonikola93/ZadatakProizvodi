using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCandMongoDB.Models.ViewModels
{
    public class AdresaViewModel
    {
        public string Mesto { get; set; }
        
        public string Ulica { get; set; }
        
        public int Broj { get; set; }
       
        public string ZIP { get; set; }
    }
}