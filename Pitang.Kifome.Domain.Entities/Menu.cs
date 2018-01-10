using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Domain.Entities
{
    public class Menu : BaseEntity<int>
    {
        public Seller Seller { get; set; }
        public List<Meal> Meals { get; set; }
        public DateTime InitialHour { get; set; }
        public DateTime FinalHour { get; set; }
        public int LimitOfMeals { get; set; }

        //public Menu(Seller seller, List<Meal> meals, DateTime initialHour, DateTime finalHour, int limitOfMeals)
        //{
        //    this.Seller = seller;
        //    this.Meals = meals;
        //    this.InitialHour = initialHour;
        //    this.FinalHour = finalHour;
        //    this.LimitOfMeals = limitOfMeals;
        //}
    }
}