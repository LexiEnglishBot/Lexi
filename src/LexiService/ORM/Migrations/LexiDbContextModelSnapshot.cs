﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ORM.DbContexts;

#nullable disable

namespace ORM.Migrations
{
    [DbContext(typeof(LexiDbContext))]
    partial class LexiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.User.Aggregate.UserAggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Bio")
                        .HasColumnType("text")
                        .HasColumnName("bio");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("firstName");

                    b.Property<bool>("HasPrivateForwards")
                        .HasColumnType("boolean")
                        .HasColumnName("hasPrivateForwards");

                    b.Property<bool>("IsBot")
                        .HasColumnType("boolean")
                        .HasColumnName("isBot");

                    b.Property<bool>("IsPremium")
                        .HasColumnType("boolean")
                        .HasColumnName("isPremium");

                    b.Property<string>("LanguageCode")
                        .HasColumnType("text")
                        .HasColumnName("languageCode");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("lastName");

                    b.Property<string>("ProfileImageObjectName")
                        .HasColumnType("text")
                        .HasColumnName("profileImageObjectName");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("userId");

                    b.Property<string>("Username")
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pK_users");

                    b.ToTable("users", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}