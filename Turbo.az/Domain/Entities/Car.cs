using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbo.az.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string Brand { get; set; }
        public bool IsNew { get; set; }
        public int Mileage { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public string FuelType { get; set; }
    }
}
