﻿// <auto-generated />
using System;
using CompanyWebApi.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CompanyWebApi.Migrations
{
    [DbContext(typeof(CompanyContext))]
    partial class CompanyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CompanyWebApi.Core.Domain.Appointment", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime?>("AppointmentDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Appointments", (string)null);
                });

            modelBuilder.Entity("CompanyWebApi.Core.Domain.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfClientInitialization")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GroupTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("GroupTypeId");

                    b.ToTable("Companies", (string)null);
                });

            modelBuilder.Entity("CompanyWebApi.Core.Domain.GroupType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("GroupTypes", (string)null);
                });

            modelBuilder.Entity("CompanyWebApi.Core.Domain.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfCompanyProductionStateInitialization")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfOrder")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateWhenContractWillExpire")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfProducts")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CompanyWebApi.Core.Domain.Product", b =>
                {
                    b.Property<int>("ProductCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductCode"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("ProductCode");

                    b.HasIndex("OrderId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CompanyWebApi.Core.Domain.Appointment", b =>
                {
                    b.HasOne("CompanyWebApi.Core.Domain.Company", null)
                        .WithMany("Appointments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CompanyWebApi.Core.Domain.Company", b =>
                {
                    b.HasOne("CompanyWebApi.Core.Domain.GroupType", "GroupType")
                        .WithMany("Company")
                        .HasForeignKey("GroupTypeId");

                    b.Navigation("GroupType");
                });

            modelBuilder.Entity("CompanyWebApi.Core.Domain.Order", b =>
                {
                    b.HasOne("CompanyWebApi.Core.Domain.Company", null)
                        .WithMany("Orders")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CompanyWebApi.Core.Domain.Product", b =>
                {
                    b.HasOne("CompanyWebApi.Core.Domain.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("CompanyWebApi.Core.Domain.Company", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("CompanyWebApi.Core.Domain.GroupType", b =>
                {
                    b.Navigation("Company");
                });

            modelBuilder.Entity("CompanyWebApi.Core.Domain.Order", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}