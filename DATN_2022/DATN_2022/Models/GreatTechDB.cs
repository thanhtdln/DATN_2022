using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DATN_2022.Models
{
    public partial class GreatTechDB : DbContext
    {
        public GreatTechDB()
            : base("name=GreatTechDB")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<EndUser> EndUsers { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<ReceiveHistory> ReceiveHistories { get; set; }
        public virtual DbSet<ShopHistory> ShopHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(e => e.AppUsers)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.EndUsers)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EndUser>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.EndUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EndUser>()
                .HasMany(e => e.ShopHistories)
                .WithRequired(e => e.EndUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producer>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Producer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Promotions)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ReceiveHistories)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ShopHistories)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);
        }
    }
}
