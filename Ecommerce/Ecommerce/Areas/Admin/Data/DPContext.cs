using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
namespace Ecommerce.Areas.Admin.Data
{
    public class DPContext : DbContext
    {
        public DPContext(DbContextOptions<DPContext> options) : base(options)
        {

        }
        public DbSet<BrandModel> Brands { get; set; }
        public DbSet<CarrierModel> Carriers { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderDetailModel> OrderDetails { get; set; }
        public DbSet<PaymentModel> Payments { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ShippingModel> Shippings { get; set; }
        public DbSet<SliderModel> Sliders { get; set; }
        public DbSet<SupplierModel> Suppliers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetailModel>()
                .HasKey(c => new { c.OrderID, c.ProductID });

            base.OnModelCreating(modelBuilder);
        }
    }
}
