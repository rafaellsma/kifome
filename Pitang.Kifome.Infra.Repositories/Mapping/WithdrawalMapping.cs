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
    public class WithdrawalMapping : EntityTypeConfiguration<Withdrawal>
    {
        public WithdrawalMapping()
        {
            this.ToTable("Withdrawal");
            this.HasKey(w => w.Id);
            this.Property(w => w.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(w => w.Street).HasColumnName("street").IsRequired();
            this.Property(w => w.Number).HasColumnName("number").IsRequired();
            this.Property(w => w.CEP).HasColumnName("CEP").IsRequired();
            this.Property(w => w.InitialHour).HasColumnName("initialHour").IsRequired();
            this.Property(w => w.FinalHour).HasColumnName("finalHour").IsRequired();
            this.Property(w => w.Latitude).HasColumnName("latitude").IsRequired();
            this.Property(w => w.Longitude).HasColumnName("longitude").IsRequired();
            this.Property(w => w.SellerId).HasColumnName("seller_id").IsRequired();
            this.HasRequired(w => w.Seller)
                .WithMany(s => s.Withdrawals)
                .HasForeignKey(w => w.SellerId);
        }
    }
}
