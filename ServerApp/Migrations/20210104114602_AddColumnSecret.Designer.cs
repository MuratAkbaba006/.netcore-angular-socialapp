﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServerApp.Data;

namespace ServerApp.Migrations
{
    [DbContext(typeof(SocialContext))]
    [Migration("20210104114602_AddColumnSecret")]
    partial class AddColumnSecret
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("ServerApp.Models.Product", b =>
                {
                    b.Property<int>("Productid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Secret")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isActive")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("price")
                        .HasColumnType("TEXT");

                    b.HasKey("Productid");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
