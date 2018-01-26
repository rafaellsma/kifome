using System;
using System.Data.Entity;

namespace Pitang.Kifome.Infra.Repositories.Mapping
{
    public class Context : DbContext
    {
        public Context() : base(Environment.GetEnvironmentVariable("CONN_KIFOME"))
        {
            Database.SetInitializer<Context>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CommentMapping());
            modelBuilder.Configurations.Add(new WithdrawalMapping());
            modelBuilder.Configurations.Add(new GarnishMapping());
            modelBuilder.Configurations.Add(new MealMapping());
            modelBuilder.Configurations.Add(new MenuMapping());
            modelBuilder.Configurations.Add(new OrderMapping());
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new ConfiguredMealMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
