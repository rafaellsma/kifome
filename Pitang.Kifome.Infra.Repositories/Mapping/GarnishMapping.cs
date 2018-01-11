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
    public class GarnishMapping : EntityTypeConfiguration<Garnish>
    {
        public GarnishMapping()
        {
            this.HasKey(g => g.Id);
            this.Property(g => g.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(g => g.Name).HasColumnName("name").IsRequired();
            this.Property(g => g.Description).HasColumnName("description");
            this.HasMany(g => g.Meals)
                .WithMany(m => m.Garnishies)
                .Map(mg =>
                {
                    mg.MapLeftKey("garnish_id");
                    mg.MapRightKey("meal_id");
                    mg.ToTable("MealGarnish");
                });
        }
    }
}
