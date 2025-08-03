using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sisharpriborn.WebFormClientRil.Models
{
    public class CarInsert
    {
        public string CarId { get; set; }
        public string VIN { get; set; }
        public string ModelType { get; set; }
        public string FuelType { get; set; }
        public double BasePrice { get; set; }
    }
}