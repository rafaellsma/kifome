using System.Data.Entity;

namespace Pitang.Kifome.Infra.Repositories.Mapping
{
    public class Context : DbContext
    {
        public Context() : base("ConnKiFomePCJP")
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
            base.OnModelCreating(modelBuilder);
        }
    }
}
