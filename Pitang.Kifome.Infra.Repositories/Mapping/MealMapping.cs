using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitang.Kifome.Domain.Entities;

namespace Pitang.Kifome.Infra.Repositories.Mapping
{
    public class MealMapping : EntityTypeConfiguration<Meal>
    {
        public MealMapping()
        {
            this.ToTable("Meal");
            this.HasKey(m => m.Id);
            this.Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Name).HasColumnName("name").IsRequired();
            this.Property(m => m.Description).HasColumnName("description");
            this.Property(m => m.Days).HasColumnName("day").IsRequired();
            this.Property(m => m.Price).HasColumnName("price").IsRequired();
            this.HasRequired(m => m.Menu)
                .WithMany(me => me.Meals);
        }
    }
}
