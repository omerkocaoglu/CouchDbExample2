using LoveSeat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoveSeat;

namespace CouchDbApplication
{
    public class Car : IBaseObject
    {
        public string Id { get; set; }
        public string Rev { get; set; }
        public string Type
        {
            get
            {
               return typeof(Car).Name;
            }
        }
        public string Number { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
    }
}
