using api.DAL.Models;
using api.DAL.Models.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace api.DAL
{
    public class DataBaseContext : IdentityDbContext<UserModel>
    {
        public DataBaseContext(DbContextOptions options) : base(options) { }
        public DbSet<DigitalProductModel> DigitalProducts { get; set; }
        public DbSet<ShippedProductModel> ShippedProducs { get; set; }
        public DbSet<ProductStylesModel> ProductStyles { get; set; }
        public DbSet<ShippingOptionModel> ShippingOptions { get; set; }
        public DbSet<TaxCode> TaxCodes { get; set; }
        public DbSet<TrackingInfoModel> TrackingInformation { get; set; }
        public DbSet<NoteModel> Notes { get; set; }
        public DbSet<CartModel> Carts { get; set; }
        public DbSet<OrderModel> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* Role and User Seeder */
            modelBuilder.ApplyConfiguration(new RoleSeeder()); // seeds the roles table
        }
    }
}
