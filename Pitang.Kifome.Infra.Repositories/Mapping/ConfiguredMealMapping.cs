using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Kifome.Infra.Repositories.Mapping
{
    public class ConfiguredMealMapping : EntityTypeConfiguration<ConfiguredMeal>
    {
        public ConfiguredMealMapping()
        {
            this.ToTable("ConfiguredMeal");
            this.HasKey(cm => cm.Id);
            this.Property(cm => cm.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(cm => cm.OrderId)
                .HasColumnName("order_id");
            this.Property(cm => cm.MealId)
              .HasColumnName("meal_id");
            this.HasRequired(cm => cm.Order)
                .WithMany(o => o.ConfiguredMeals)
                .HasForeignKey(cm => cm.OrderId);
            this.HasRequired(cm => cm.Meal)
                .WithMany(m => m.ConfiguredMeals)
                .HasForeignKey(cm => cm.MealId);
        }
    }
}
