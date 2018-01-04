using Pitang.Kifome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitangueiros.Kifome.Infra.Repositories.Repository
{
    public class Context : DbContext
    {
        public Context() : base("Server=localhost;Database=Kifome;Trusted_Connection=True;") { }

        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Garnish> Garnishies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Map Customer
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.Id);

            //Map Seller
            modelBuilder.Entity<Seller>()
                .HasKey(s => s.Id);

            //Map Garnish
            modelBuilder.Entity<Garnish>()
                .HasKey(g => g.Id);

            //Map User
            modelBuilder.Entity<User>()
                .HasKey(p => p.Id);

            //Map Order
            modelBuilder.Entity<Order>()
                .HasKey(o => o.Id);

            //Map Meal
            modelBuilder.Entity<Meal>()
                 .HasKey(m => m.Id);

            //Map Menu
            modelBuilder.Entity<Menu>()
                 .HasKey(m => m.Id);

            //Map Delivery
            modelBuilder.Entity<Delivery>()
                .HasKey(d => d.Id);

            //Map Comment
            modelBuilder.Entity<Comment>()
                .HasKey(c => c.Id);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
