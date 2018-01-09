using System.Data.Entity;

namespace Pitang.Kifome.Infra.Repositories.Mapping
{
    public class Context : DbContext
    {
        public Context() : base("Server=localhost;Database=Kifome;Trusted_Connection=True;")
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
            base.OnModelCreating(modelBuilder);
        }
    }
}
