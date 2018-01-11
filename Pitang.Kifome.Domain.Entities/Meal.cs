using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class Meal : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public Menu Menu { get; set; }
        public List<Garnish> Garnishies { get; set; }
        public List<Order> Orders { get; set; }
        public DayOfWeek Days { get; set; }

        public Meal(string name, string description, float price, Menu menu, List<Garnish> garnishes, DayOfWeek days)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Menu = menu;
            this.Garnishies = garnishes;
            this.Days = days;
        }
    }
}