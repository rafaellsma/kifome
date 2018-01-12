using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.IO;
using System.Linq;
using System.Text;

namespace Pitang.Kifome.Infra.Repositories.Mapping
{
    public class SellerMapping : EntityTypeConfiguration<User>
    {
        public SellerMapping()
        {
            this.ToTable("User");
            this.HasKey(s => s.Id);
            this.Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.Name).HasColumnName("name").IsRequired();
            this.Property(s => s.Email).HasColumnName("email").IsRequired();
            this.Property(s => s.Password).HasColumnName("password").IsRequired();
            this.Property(s => s.Rate).HasColumnName("rate");
            this.Map(s => s.Requires("discriminator").HasValue("S"));
        }
    }
}