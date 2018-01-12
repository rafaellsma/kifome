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
    public class DeliveryMapping : EntityTypeConfiguration<Delivery>
    {
        public DeliveryMapping()
        {
            this.ToTable("Delivery");
            this.HasKey(d => d.Id);
            this.Property(d => d.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(d => d.Street).HasColumnName("street").IsRequired();
            this.Property(d => d.Number).HasColumnName("number").IsRequired();
            this.Property(d => d.CEP).HasColumnName("CEP").IsRequired();
            this.Property(d => d.InitialHour).HasColumnName("initialHour").IsRequired();
            this.Property(d => d.FinalHour).HasColumnName("finalHour").IsRequired();
            this.Property(d => d.Latitude).HasColumnName("latitude").IsRequired();
            this.Property(d => d.Longitude).HasColumnName("longitude").IsRequired();
            this.HasRequired(d => d.Seller)
                .WithMany(s => s.Deliveries);
        }
    }
}
