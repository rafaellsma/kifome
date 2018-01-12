using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class Delivery : BaseEntity<int>
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string CEP { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime InitialHour { get; set; }
        public DateTime FinalHour { get; set; }
        public User Seller { get; set; }
    }
}