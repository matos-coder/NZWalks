﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test.api.data;

#nullable disable

namespace test.api.Migrations
{
    [DbContext(typeof(walksDbContext))]
    [Migration("20231204113949_seeding data for difficulties")]
    partial class seedingdatafordifficulties
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("test.api.models.domain.difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7fc7a14d-7f58-4d2c-b8a8-d6a32ab24b20"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("0dad2a68-a6a4-4fa3-b8e8-c569574755d4"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("a70bad79-5326-4f14-ad02-6e557855281f"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("test.api.models.domain.region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("regions");
                });

            modelBuilder.Entity("test.api.models.domain.walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WalkImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("difficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("regionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("difficultyId");

                    b.HasIndex("regionId");

                    b.ToTable("walks");
                });

            modelBuilder.Entity("test.api.models.domain.walk", b =>
                {
                    b.HasOne("test.api.models.domain.difficulty", "difficulty")
                        .WithMany()
                        .HasForeignKey("difficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("test.api.models.domain.region", "region")
                        .WithMany()
                        .HasForeignKey("regionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("difficulty");

                    b.Navigation("region");
                });
#pragma warning restore 612, 618
        }
    }
}
