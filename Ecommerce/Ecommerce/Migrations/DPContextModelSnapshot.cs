﻿// <auto-generated />
using Ecommerce.Areas.Admin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ecommerce.Migrations
{
    [DbContext(typeof(DPContext))]
    partial class DPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Ecommerce.Areas.Admin.Models.AdminModel", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AdminEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminPicture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminID");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("Ecommerce.Areas.Admin.Models.BrandModel", b =>
                {
                    b.Property<int>("BrandID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BrandDescription")
                        .HasColumnType("int");

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrandPicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrandStatus")
                        .HasColumnType("int");

                    b.HasKey("BrandID");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("Ecommerce.Areas.Admin.Models.CarriersModel", b =>
                {
                    b.Property<int>("CarrierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<long>("CarrierName")
                        .HasColumnType("bigint");

                    b.Property<string>("CarrierStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarrierID");

                    b.ToTable("Carrier");
                });

            modelBuilder.Entity("Ecommerce.Areas.Admin.Models.CategoryModel", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryKeyWord")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryPicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryStatus")
                        .HasColumnType("int");

                    b.HasKey("CategoryID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Ecommerce.Areas.Admin.Models.CouponModel", b =>
                {
                    b.Property<int>("CouponID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CouponCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CouponName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CouponStatus")
                        .HasColumnType("int");

                    b.HasKey("CouponID");

                    b.ToTable("Coupon");
                });

            modelBuilder.Entity("Ecommerce.Areas.Admin.Models.CustomersModel", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CustomerAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerStatus")
                        .HasColumnType("int");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Ecommerce.Areas.Admin.Models.OrderDetailsModel", b =>
                {
                    b.Property<int>("OrderDetailID")
                        .HasColumnType("int");

                    b.Property<int>("OrderDetailProductID")
                        .HasColumnType("int");

                    b.Property<string>("OrderDetailColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderDetailCoupon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderDetailNumber")
                        .HasColumnType("int");

                    b.Property<long>("OrderDetailPrice")
                        .HasColumnType("bigint");

                    b.Property<int>("OrderDetailProductName")
                        .HasColumnType("int");

                    b.Property<string>("OrderDetailState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailID", "OrderDetailProductID");

                    b.HasIndex("OrderDetailProductID");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("Ecommerce.Areas.Admin.Models.OrdersModel", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("OrderCarrierID")
                        .HasColumnType("int");

                    b.Property<string>("OrderCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderCustomerID")
                        .HasColumnType("int");

                    b.Property<int>("OrderPaymentID")
                        .HasColumnType("int");

                    b.Property<string>("OrderShipAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<long>("OrderTotalMoney")
                        .HasColumnType("bigint");

                    b.HasKey("OrderID");

                    b.HasIndex("OrderCarrierID");

                    b.HasIndex("OrderCustomerID");

                    b.HasIndex("OrderPaymentID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Ecommerce.Areas.Admin.Models.PaymentModel", b =>
                {
                    b.Property<int>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("PaymentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.HasKey("PaymentID");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Ecommerce.Areas.Admin.Models.ProductModel", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ProductBrandID")
                        .HasColumnType("int");

                    b.Property<int>("ProductCategoryID")
                        .HasColumnType("int");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProductDiscount")
                        .HasColumnType("bigint");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductNumber")
                        .HasColumnType("int");

                    b.Property<string>("ProductPicture1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductPicture2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductPicture3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProductPrice")
                        .HasColumnType("bigint");

                    b.Property<int>("ProductStatus")
                        .HasColumnType("int");

                    b.Property<int>("ProductSupplierID")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.HasIndex("ProductBrandID");

                    b.HasIndex("ProductCategoryID");

                    b.HasIndex("ProductSupplierID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Ecommerce.Areas.Admin.Models.SuppliersModel", b =>
                {
                    b.Property<int>("SupplierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<long>("SupplierAdress")
                        .HasColumnType("bigint");

                    b.Property<int>("SupplierLogo")
                        .HasColumnType("int");

                    b.Property<string>("SupplierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupplierStatus")
                        .HasColumnType("int");

                    b.HasKey("SupplierID");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("Ecommerce.Areas.Admin.Models.OrderDetailsModel", b =>
                {
                    b.HasOne("Ecommerce.Areas.Admin.Models.OrdersModel", "Orders")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderDetailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommerce.Areas.Admin.Models.ProductModel", "Products")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderDetailProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Ecommerce.Areas.Admin.Models.OrdersModel", b =>
                {
                    b.HasOne("Ecommerce.Areas.Admin.Models.CarriersModel", "Carriers")
                        .WithMany("Orders")
                        .HasForeignKey("OrderCarrierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommerce.Areas.Admin.Models.CustomersModel", "Customers")
                        .WithMany("Orders")
                        .HasForeignKey("OrderCustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommerce.Areas.Admin.Models.PaymentModel", "Payments")
                        .WithMany("Orders")
                        .HasForeignKey("OrderPaymentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carriers");

                    b.Navigation("Customers");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Ecommerce.Areas.Admin.Models.ProductModel", b =>
                {
                    b.HasOne("Ecommerce.Areas.Admin.Models.BrandModel", "Brands")
                        .WithMany("Products")
                        .HasForeignKey("ProductBrandID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommerce.Areas.Admin.Models.CategoryModel", "Categorys")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommerce.Areas.Admin.Models.SuppliersModel", "Suppliers")
                        .WithMany("Products")
                        .HasForeignKey("ProductSupplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brands");

                    b.Navigation("Categorys");

                    b.Navigation("Suppliers");
                });

            modelBuilder.Entity("Ecommerce.Areas.Admin.Models.BrandModel", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Ecommerce.Areas.Admin.Models.CarriersModel", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Ecommerce.Areas.Admin.Models.CategoryModel", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Ecommerce.Areas.Admin.Models.CustomersModel", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Ecommerce.Areas.Admin.Models.OrdersModel", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Ecommerce.Areas.Admin.Models.PaymentModel", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Ecommerce.Areas.Admin.Models.ProductModel", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Ecommerce.Areas.Admin.Models.SuppliersModel", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
