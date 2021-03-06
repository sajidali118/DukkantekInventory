// <auto-generated />
using System;
using Dukkantek.EntityFrameWork.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dukkantek.EF.Migrations
{
    [DbContext(typeof(EFContext))]
    [Migration("20220318074042_initalMigrations")]
    partial class initalMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dukkantek.Domain.Models.Logs.Audit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AuditDateTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("AuditType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("AuditUser")
                        .HasColumnType("bigint");

                    b.Property<string>("ChangedColumns")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KeyValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TableName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("Dukkantek.Domain.Models.Products.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long?>("LastModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Electronic Devices",
                            ShortName = "Electronic Devices"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Health & Beauty",
                            ShortName = "Health & Beauty"
                        },
                        new
                        {
                            Id = 3L,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Sports & Outdoor",
                            ShortName = "Sports & Outdoor"
                        });
                });

            modelBuilder.Entity("Dukkantek.Domain.Models.Products.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Barcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long?>("LastModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Barcode = "xxxxxxxxxxxxxxx",
                            CategoryId = 1L,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "BuildOSIOS 15 DimensionsN/A WeightN/A SIMDual Sim, Dual Standby (Nano-SIM) ColorsVarious Frequency2G BandSIM1: GSM 850 / 900 / 1800 / 1900",
                            IsDeleted = false,
                            Name = "IPhone 13 Pro",
                            Status = 2,
                            Weight = 90
                        },
                        new
                        {
                            Id = 2L,
                            Barcode = "xxxxxxxxxxxxxxx123",
                            CategoryId = 1L,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "BuildOSIOS 15 DimensionsN/A WeightN/A SIMDual Sim, Dual Standby (Nano-SIM) ColorsVarious Frequency2G BandSIM1: GSM 850 / 900 / 1800 / 1900",
                            IsDeleted = false,
                            Name = "IPhone 12 Pro",
                            Status = 2,
                            Weight = 85
                        },
                        new
                        {
                            Id = 3L,
                            Barcode = "xxxxxxxxxxxxxxx234",
                            CategoryId = 1L,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "BuildOSIOS 15 DimensionsN/A WeightN/A SIMDual Sim, Dual Standby (Nano-SIM) ColorsVarious Frequency2G BandSIM1: GSM 850 / 900 / 1800 / 1900",
                            IsDeleted = false,
                            Name = "IPhone 13 Pro MAX",
                            Status = 1,
                            Weight = 95
                        },
                        new
                        {
                            Id = 4L,
                            Barcode = "xxxxxxxxxxxxxxx3333",
                            CategoryId = 1L,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "BuildOSIOS 15 DimensionsN/A WeightN/A SIMDual Sim, Dual Standby (Nano-SIM) ColorsVarious Frequency2G BandSIM1: GSM 850 / 900 / 1800 / 1900",
                            IsDeleted = false,
                            Name = "IPhone 12 Pro MAX",
                            Status = 3,
                            Weight = 95
                        });
                });

            modelBuilder.Entity("Dukkantek.Domain.Models.Products.ProductSell", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long?>("LastModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductSells");
                });

            modelBuilder.Entity("Dukkantek.Domain.Models.Products.Product", b =>
                {
                    b.HasOne("Dukkantek.Domain.Models.Products.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("Dukkantek.Domain.Models.Products.ProductSell", b =>
                {
                    b.HasOne("Dukkantek.Domain.Models.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
