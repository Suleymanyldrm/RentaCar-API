﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentaCar_API.Data;

namespace RentaCar_API.Migrations
{
    [DbContext(typeof(RentaCarContext))]
    [Migration("20220531093347_deletedBrandcolon")]
    partial class deletedBrandcolon
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RentaCar_API.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("RentaCar_API.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<int?>("CarModalId")
                        .HasColumnType("int");

                    b.Property<int?>("ClassificationId")
                        .HasColumnType("int");

                    b.Property<int?>("FuelTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ImgURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OfficiesId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("TransmissionTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CarModalId");

                    b.HasIndex("ClassificationId");

                    b.HasIndex("FuelTypeId");

                    b.HasIndex("OfficiesId");

                    b.HasIndex("TransmissionTypeId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("RentaCar_API.Entities.CarModal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("CarModals");
                });

            modelBuilder.Entity("RentaCar_API.Entities.Classification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Classifications");
                });

            modelBuilder.Entity("RentaCar_API.Entities.FuelType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FuelTypes");
                });

            modelBuilder.Entity("RentaCar_API.Entities.Officies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Officies");
                });

            modelBuilder.Entity("RentaCar_API.Entities.RentedCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DropOffDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PickUpDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("RentedCars");
                });

            modelBuilder.Entity("RentaCar_API.Entities.TransmissionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TransmissionTypes");
                });

            modelBuilder.Entity("RentaCar_API.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Password")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RentaCar_API.Entities.Car", b =>
                {
                    b.HasOne("RentaCar_API.Entities.Brand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("BrandId");

                    b.HasOne("RentaCar_API.Entities.CarModal", "CarModal")
                        .WithMany("Cars")
                        .HasForeignKey("CarModalId");

                    b.HasOne("RentaCar_API.Entities.Classification", "Classification")
                        .WithMany("Cars")
                        .HasForeignKey("ClassificationId");

                    b.HasOne("RentaCar_API.Entities.FuelType", "FuelType")
                        .WithMany("Cars")
                        .HasForeignKey("FuelTypeId");

                    b.HasOne("RentaCar_API.Entities.Officies", "Officies")
                        .WithMany("Cars")
                        .HasForeignKey("OfficiesId");

                    b.HasOne("RentaCar_API.Entities.TransmissionType", "TransmissionType")
                        .WithMany("Cars")
                        .HasForeignKey("TransmissionTypeId");

                    b.Navigation("Brand");

                    b.Navigation("CarModal");

                    b.Navigation("Classification");

                    b.Navigation("FuelType");

                    b.Navigation("Officies");

                    b.Navigation("TransmissionType");
                });

            modelBuilder.Entity("RentaCar_API.Entities.CarModal", b =>
                {
                    b.HasOne("RentaCar_API.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("RentaCar_API.Entities.RentedCar", b =>
                {
                    b.HasOne("RentaCar_API.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");

                    b.HasOne("RentaCar_API.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RentaCar_API.Entities.Brand", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("RentaCar_API.Entities.CarModal", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("RentaCar_API.Entities.Classification", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("RentaCar_API.Entities.FuelType", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("RentaCar_API.Entities.Officies", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("RentaCar_API.Entities.TransmissionType", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
