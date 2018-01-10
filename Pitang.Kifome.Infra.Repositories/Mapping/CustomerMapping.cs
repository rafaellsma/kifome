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
    public class CustomerMapping : EntityTypeConfiguration<Customer>
    {
        public CustomerMapping()
        {
            this.ToTable("User");
            this.HasKey(c => c.Id);
            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Name).HasColumnName("name").IsRequired();
            this.Property(c => c.Email).HasColumnName("email").IsRequired();
            this.Property(c => c.Password).HasColumnName("password").IsRequired();
            this.Map(c => c.Requires("rate").HasValue(null));
            this.Map(c => c.Requires("discriminator").HasValue("C"));
        }
    }
}
