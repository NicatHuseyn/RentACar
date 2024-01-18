using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km { get; set; } // 7
        public string Transmission { get; set; }
        public byte SeatCount { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
        public ICollection<CarFeature> CarFeatures { get; set; }
        public ICollection<CarDescription> CarDescriptions { get; set; }
        public ICollection<CarPricing> CarPricings { get; set; }
    }
}
