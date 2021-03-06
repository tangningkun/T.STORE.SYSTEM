﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using T.STORE.SYSTEM.EntityFrameworkCore;

namespace T.STORE.SYSTEM.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20191216143658_initialization")]
    partial class initialization
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("T.STORE.SYSTEM.Domain.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<int?>("Component");

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("Icon");

                    b.Property<string>("IsPage");

                    b.Property<string>("Name");

                    b.Property<byte[]>("Pid")
                        .IsRequired()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<string>("Sort");

                    b.Property<byte[]>("TenantId")
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("T.STORE.SYSTEM.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateTime");

                    b.Property<bool>("IsAdmin");

                    b.Property<bool?>("IsUse");

                    b.Property<string>("MenuIds");

                    b.Property<string>("RoleName");

                    b.Property<byte[]>("TenantId")
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("T.STORE.SYSTEM.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Account");

                    b.Property<string>("ApiKey");

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("Password");

                    b.Property<byte[]>("TenantId")
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<string>("UserName");

                    b.Property<int?>("departmentId");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("T.STORE.SYSTEM.Domain.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateTime");

                    b.Property<int>("RoleId");

                    b.Property<byte[]>("TenantId")
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
