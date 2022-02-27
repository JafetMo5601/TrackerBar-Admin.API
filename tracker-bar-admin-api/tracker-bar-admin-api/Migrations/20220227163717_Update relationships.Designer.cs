﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tracker_bar_admin_api.DataModels;

#nullable disable

namespace tracker_bar_admin_api.Migrations
{
    [DbContext(typeof(UserAdminContext))]
    [Migration("20220227163717_Update relationships")]
    partial class Updaterelationships
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("tracker_bar_admin_api.DataModels.Direction", b =>
                {
                    b.Property<int>("DirectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DirectionId"), 1L, 1);

                    b.Property<string>("DirectionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DirectionId");

                    b.HasIndex("UserId");

                    b.ToTable("Directions");
                });

            modelBuilder.Entity("tracker_bar_admin_api.DataModels.Phone", b =>
                {
                    b.Property<int>("PhoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhoneId"), 1L, 1);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PhoneId");

                    b.HasIndex("UserId");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("tracker_bar_admin_api.DataModels.Receipt", b =>
                {
                    b.Property<int>("ReceiptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReceiptId"), 1L, 1);

                    b.Property<int>("ReceiptDetailId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReceiptId");

                    b.HasIndex("ReceiptDetailId");

                    b.HasIndex("UserId");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("tracker_bar_admin_api.DataModels.ReceiptDetail", b =>
                {
                    b.Property<int>("ReceiptDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReceiptDetailId"), 1L, 1);

                    b.Property<float>("Fees")
                        .HasColumnType("real");

                    b.Property<int>("PeopleQty")
                        .HasColumnType("int");

                    b.Property<float>("SubtotalPrice")
                        .HasColumnType("real");

                    b.Property<int>("TableNumber")
                        .HasColumnType("int");

                    b.HasKey("ReceiptDetailId");

                    b.ToTable("ReceiptDetail");
                });

            modelBuilder.Entity("tracker_bar_admin_api.DataModels.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantId"), 1L, 1);

                    b.Property<int>("EmployeeQty")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PeopleQty")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TableQty")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RestaurantId");

                    b.HasIndex("UserId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("tracker_bar_admin_api.DataModels.RestaurantDirection", b =>
                {
                    b.Property<int>("RestaurantDirectionId")
                        .HasColumnType("int");

                    b.Property<string>("Direction")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurantDirectionId");

                    b.ToTable("RestaurantDirection");
                });

            modelBuilder.Entity("tracker_bar_admin_api.DataModels.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("RoleDescription")
                        .HasColumnType("int");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("tracker_bar_admin_api.DataModels.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("tracker_bar_admin_api.DataModels.Direction", b =>
                {
                    b.HasOne("tracker_bar_admin_api.DataModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("tracker_bar_admin_api.DataModels.Phone", b =>
                {
                    b.HasOne("tracker_bar_admin_api.DataModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("tracker_bar_admin_api.DataModels.Receipt", b =>
                {
                    b.HasOne("tracker_bar_admin_api.DataModels.ReceiptDetail", "ReceiptDetail")
                        .WithMany("Receipts")
                        .HasForeignKey("ReceiptDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tracker_bar_admin_api.DataModels.User", "User")
                        .WithMany("Receipts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReceiptDetail");

                    b.Navigation("User");
                });

            modelBuilder.Entity("tracker_bar_admin_api.DataModels.Restaurant", b =>
                {
                    b.HasOne("tracker_bar_admin_api.DataModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("tracker_bar_admin_api.DataModels.RestaurantDirection", b =>
                {
                    b.HasOne("tracker_bar_admin_api.DataModels.Restaurant", "Restaurant")
                        .WithOne("Direction")
                        .HasForeignKey("tracker_bar_admin_api.DataModels.RestaurantDirection", "RestaurantDirectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("tracker_bar_admin_api.DataModels.Role", b =>
                {
                    b.HasOne("tracker_bar_admin_api.DataModels.User", "User")
                        .WithOne("Role")
                        .HasForeignKey("tracker_bar_admin_api.DataModels.Role", "RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("tracker_bar_admin_api.DataModels.ReceiptDetail", b =>
                {
                    b.Navigation("Receipts");
                });

            modelBuilder.Entity("tracker_bar_admin_api.DataModels.Restaurant", b =>
                {
                    b.Navigation("Direction");
                });

            modelBuilder.Entity("tracker_bar_admin_api.DataModels.User", b =>
                {
                    b.Navigation("Receipts");

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
