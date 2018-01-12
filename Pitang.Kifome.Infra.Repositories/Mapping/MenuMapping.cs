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
    public class MenuMapping : EntityTypeConfiguration<Menu>
    {
        public MenuMapping()
        {
            this.ToTable("Menu");
            this.HasKey(m => m.Id);
            this.Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.InitialHour).HasColumnName("initialTimeToOrder").IsRequired();
            this.Property(m => m.FinalHour).HasColumnName("finalTimeToOrder").IsRequired();
            this.Property(m => m.LimitOfMeals).HasColumnName("limitOfMeals").IsRequired();
            this.HasRequired(m => m.Seller);
        }
    }
}
