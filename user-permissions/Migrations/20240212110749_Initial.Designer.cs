﻿// <auto-generated />
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using user_permissions;

#nullable disable

namespace user_permissions.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240212110749_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IO.Swagger.Models.UserPermissions", b =>
                {
                    b.Property<string>("UserRole")
                        .HasColumnType("text");

                    b.Property<List<string>>("Permissions")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.HasKey("UserRole");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            UserRole = "MANAGER",
                            Permissions = new List<string> { "1", "2", "3" }
                        },
                        new
                        {
                            UserRole = "HRPARTNER",
                            Permissions = new List<string> { "1", "2", "3" }
                        },
                        new
                        {
                            UserRole = "HRDEV",
                            Permissions = new List<string> { "1", "2", "3" }
                        },
                        new
                        {
                            UserRole = "SUPERUSER",
                            Permissions = new List<string> { "1", "2", "3" }
                        });
                });

            modelBuilder.Entity("IO.Swagger.Models.UserRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("UserLogin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("_UserRole")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
