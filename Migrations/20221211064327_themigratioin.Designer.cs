// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SMS_MVCAPP.Context;

#nullable disable

namespace SMSMVCAPP.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20221211064327_themigratioin")]
    partial class themigratioin
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SMS_MVCAPP.Models.Entities.Admin", b =>
                {
                    b.Property<string>("StaffId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("Gender")
                        .HasColumnType("longtext");

                    b.Property<string>("GuarantorName")
                        .HasColumnType("longtext");

                    b.Property<string>("HomeAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("RegisteredDate")
                        .HasColumnType("longtext");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("StaffId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("SMS_MVCAPP.Models.Entities.Attendant", b =>
                {
                    b.Property<string>("StaffId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("Gender")
                        .HasColumnType("longtext");

                    b.Property<string>("GuarantorName")
                        .HasColumnType("longtext");

                    b.Property<string>("HomeAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("RegisteredDate")
                        .HasColumnType("longtext");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("StaffId");

                    b.ToTable("Attendants");
                });

            modelBuilder.Entity("SMS_MVCAPP.Models.Entities.Product", b =>
                {
                    b.Property<string>("BarCode")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ProductCategory")
                        .HasColumnType("longtext");

                    b.Property<string>("ProductName")
                        .HasColumnType("longtext");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("BarCode");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SMS_MVCAPP.Models.Entities.Transaction", b =>
                {
                    b.Property<string>("ReceiptNo")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BarCode")
                        .HasColumnType("longtext");

                    b.Property<string>("CustomerName")
                        .HasColumnType("longtext");

                    b.Property<string>("PaymentType")
                        .HasColumnType("longtext");

                    b.Property<string>("ProductName")
                        .HasColumnType("longtext");

                    b.Property<int>("QuantityPurchased")
                        .HasColumnType("int");

                    b.Property<string>("StaffId")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("TransactionDate")
                        .HasColumnType("longtext");

                    b.HasKey("ReceiptNo");

                    b.ToTable("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
