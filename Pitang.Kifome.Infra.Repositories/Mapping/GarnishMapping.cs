﻿using System;
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
            this.ToTable("Garnish");
            this.HasKey(g => g.Id);
            this.Property(g => g.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(g => g.Name).HasColumnName("name").IsRequired();
            this.Property(g => g.Description).HasColumnName("description");
            this.Property(g => g.SellerId).HasColumnName("seller_id");
            this.HasRequired(g => g.Seller)
                .WithMany(s => s.Garnishes)
                .HasForeignKey(g => g.SellerId);
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
