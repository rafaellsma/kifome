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
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            this.ToTable("User");
            this.HasKey(u => u.Id);
            this.Property(u => u.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(u => u.Email).HasColumnName("email").IsRequired();
            this.Property(u => u.Name).HasColumnName("name").IsRequired();
            this.Property(u => u.Password).HasColumnName("password").IsRequired();
            this.Property(u => u.Rate).HasColumnName("rate");
        }
    }
}
