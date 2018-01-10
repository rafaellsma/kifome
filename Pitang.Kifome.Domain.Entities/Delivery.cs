using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class Delivery : BaseEntity<int>
    {
        public string Local { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime InitialHour { get; set; }
        public DateTime FinalHour { get; set; }
        public Seller Seller { get; set; }

        //public Delivery(string local, double latitude, double longitude, DateTime initialHour, DateTime finalHour, Seller seller)
        //{
        //    this.Local = local;
        //    this.Latitude = latitude;
        //    this.Longitude = longitude;
        //    this.InitialHour = initialHour;
        //    this.FinalHour = finalHour;
        //    this.Seller = seller;
        //}
    }
}