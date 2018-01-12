﻿using System.Data.Entity;

namespace Pitang.Kifome.Infra.Repositories.Mapping
{
    public class Context : DbContext
    {
        public Context() : base("Data Source=NBQUALITI-12;Initial Catalog=Kifome;Integrated Security=True")
        {
            Database.SetInitializer<Context>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CommentMapping());
            modelBuilder.Configurations.Add(new DeliveryMapping());
            modelBuilder.Configurations.Add(new GarnishMapping());
            modelBuilder.Configurations.Add(new MealMapping());
            modelBuilder.Configurations.Add(new MenuMapping());
            modelBuilder.Configurations.Add(new OrderMapping());
            //modelBuilder.Configurations.Add(new SellerMapping());
            //modelBuilder.Configurations.Add(new CustomerMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
