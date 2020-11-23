using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Areas.Admin.Models;
namespace Ecommerce.Areas.Admin.Data
{
    public class DPContext: DbContext
    {
        public DPContext(DbContextOptions<DPContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            // Set Khoá Chính Cho Các Bảng 
            //---------------------------//
            modelBuilder.Entity<AdminModel>()
                .HasKey(c => c.AdminID);
            modelBuilder.Entity<BrandModel>()
                .HasKey(c => c.BrandID);
            modelBuilder.Entity<CarriersModel>()
                .HasKey(c => c.CarrierID);
            modelBuilder.Entity<CategoryModel>()
                .HasKey(c => c.CategoryID);
            modelBuilder.Entity<CouponModel>()
                .HasKey(c => c.CouponID);
            modelBuilder.Entity<CustomersModel>()
                .HasKey(c => c.CustomerID);
            modelBuilder.Entity<OrdersModel>()
                .HasKey(c => c.OrderID);
            modelBuilder.Entity<PaymentModel>()
                .HasKey(c => c.PaymentID);
            modelBuilder.Entity<SuppliersModel>()
                .HasKey(c => c.SupplierID);
            modelBuilder.Entity<ProductModel>()
                .HasKey(c => c.ProductID);
            modelBuilder.Entity<OrderDetailsModel>()
                .HasKey(c => new { c.OrderDetailID, c.OrderDetailProductID });
            //---------------------------//
            //FK_Carrier-Order
            modelBuilder.Entity<OrdersModel>()
            .HasOne(p => p.Carriers)
            .WithMany(b => b.Orders)
            .HasForeignKey(p => p.OrderCarrierID);
            //FK_Carrier-Order

            modelBuilder.Entity<OrdersModel>()
            .HasOne(p => p.Customers)
            .WithMany(b => b.Orders)
            .HasForeignKey(p => p.OrderCustomerID);


            //FK_Payment-Order
            modelBuilder.Entity<OrdersModel>()
            .HasOne(p => p.Payments)
            .WithMany(b => b.Orders)
            .HasForeignKey(p => p.OrderPaymentID);
                
            //FK_Supplier-Order
            modelBuilder.Entity<ProductModel>()
            .HasOne(p => p.Suppliers)
            .WithMany(b => b.Products)
            .HasForeignKey(p => p.ProductSupplierID);


            //FK_Product-Category
            modelBuilder.Entity<ProductModel>()
            .HasOne(p => p.Categorys)
            .WithMany(b => b.Products)
            .HasForeignKey(p => p.ProductCategoryID);

            modelBuilder.Entity<ProductModel>()
            .HasOne(p => p.Brands)
            .WithMany(b => b.Products)
            .HasForeignKey(p => p.ProductBrandID);

            modelBuilder.Entity<OrderDetailsModel>()
            .HasOne(p => p.Products)
            .WithMany(b => b.OrderDetails)
            .HasForeignKey(p => p.OrderDetailProductID);

            modelBuilder.Entity<OrderDetailsModel>()
            .HasOne(p => p.Orders)
            .WithMany(b => b.OrderDetails)
            .HasForeignKey(p => p.OrderDetailID);

            //FK Bảng Product Và OrderDetail 1 chi tiet hoa don co nhieu san pham
            //modelBuilder.Entity<OrderDetailsModel>(entity =>
            //{
            //    // Thiết lập cho bảng Product
            //    entity.HasOne(e => e.Products)
            //            .WithMany(product => product.OrderDetails)
            //            .HasForeignKey("OrderDetailProductID")
            //            .OnDelete(DeleteBehavior.SetNull)
            //            .HasConstraintName("FK_Products_OrderDetails");

            //});


            //FK Bảng Order Và Customer  1 Khách Hàng có thể có tao nhiều hoá đơn
            //modelBuilder.Entity<OrdersModel>(entity =>
            //{
            //    // Thiết lập cho bảng Order
            //    entity.HasOne(e => e.Customers)
            //            .WithMany(customer => customer.Orders)
            //            .HasForeignKey("OrderCustomerID")
            //            .OnDelete(DeleteBehavior.SetNull)
            //            .HasConstraintName("FK_Order_Customer");
            //});



            //Ràng buộc FK Em Tham Khảo trên: https://xuanthulab.net/ef-core-tao-quan-he-trong-entity-framework-voi-fluent-api-c-csharp.html
            //---------------------------//


            //modelBuilder.Entity<OrderDetailsModel>()
            //.HasOne<OrdersModel>(o => o.Orders)
            //.WithOne(od => od.OrderDetails)
            //.HasForeignKey<OrdersModel>(ad => ad.OrderID)
            //.HasConstraintName("FK_Order_OrderDetails");

            //modelBuilder.Entity<OrdersModel>()
            //.HasOne<CarriersModel>(o => o.Carriers)
            //.WithOne(od => od.Orders)
            //.HasForeignKey<CarriersModel>(ad => ad.Orders)
            //.HasConstraintName("FK_Order_OrderDetails");

            //FK Bảng Product Và OrderDetail 1 chi tiet hoa don co nhieu san pham
            //modelBuilder.Entity<OrderDetailsModel>(entity =>
            //{
            //    // Thiết lập cho bảng Product
            //    entity.HasOne(e => e.Products)
            //            .WithMany(product => product.OrderDetails)
            //            .HasForeignKey("OrderDetailProductID")
            //            .OnDelete(DeleteBehavior.SetNull)
            //            .HasConstraintName("FK_Products_OrderDetails");
            //});

            //FK Bảng Order Và OrderDetail 1 chi tiet hoa don co 1 MaHD
            //---------------------------//
        }

        public DbSet<ProductModel> Product { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<AdminModel> Admin { get; set; }
        public DbSet<BrandModel> Brand { get; set; }
        public DbSet<CarriersModel> Carrier { get; set; }
        public DbSet<CouponModel> Coupon { get; set; }
        public DbSet<CustomersModel> Customer { get; set; }
        public DbSet<OrderDetailsModel> OrderDetail { get; set; }
        public DbSet<OrdersModel> Order { get; set; }
        public DbSet<PaymentModel> Payment { get; set; }
        public DbSet<SuppliersModel> Supplier { get; set; }

    }
}
