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
    public class OrderMapping : EntityTypeConfiguration<Order>
    {
        public OrderMapping()
        {
            this.ToTable("Order");
            this.HasKey(o => o.Id);
            this.Property(o => o.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(o => o.Status).HasColumnName("status").IsRequired();
            this.HasRequired(o => o.Seller).WithMany(u => u.ReceivedOrders);
            this.HasRequired(o => o.Customer).WithMany(u => u.MadeOrders);
            this.HasRequired(o => o.Withdrawal);
        }
    }
}
