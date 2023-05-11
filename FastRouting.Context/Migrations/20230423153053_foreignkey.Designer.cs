﻿// <auto-generated />
using FastRouting.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FastRouting.Context.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230423153053_foreignkey")]
    partial class foreignkey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FastRouting.Repositories.Entities.Coordinate", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<double>("x")
                        .HasColumnType("float");

                    b.Property<double>("y")
                        .HasColumnType("float");

                    b.Property<int>("z")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Coordinate");
                });

            modelBuilder.Entity("FastRouting.Repositories.Entities.Edges", b =>
                {
                    b.Property<int>("LocationIdA")
                        .HasColumnType("int");

                    b.Property<int>("LocationIdB")
                        .HasColumnType("int");

                    b.Property<double>("Distance")
                        .HasColumnType("float");

                    b.Property<int>("centerId")
                        .HasColumnType("int");

                    b.HasKey("LocationIdA", "LocationIdB");

                    b.ToTable("Edges");
                });

            modelBuilder.Entity("FastRouting.Repositories.Entities.Intersections", b =>
                {
                    b.Property<int>("IntersectionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IntersectionID"));

                    b.Property<int>("Coordinateid")
                        .HasColumnType("int");

                    b.Property<int>("centerId")
                        .HasColumnType("int");

                    b.HasKey("IntersectionID");

                    b.HasIndex("Coordinateid");

                    b.ToTable("Intersections");
                });

            modelBuilder.Entity("FastRouting.Repositories.Entities.Location", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("centerId")
                        .HasColumnType("int");

                    b.Property<int>("coordinateid")
                        .HasColumnType("int");

                    b.Property<string>("locationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("locationTypesId")
                        .HasColumnType("int");

                    b.Property<int>("transitionId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("coordinateid");

                    b.HasIndex("locationTypesId");

                    b.HasIndex("transitionId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("FastRouting.Repositories.Entities.LocationTypes", b =>
                {
                    b.Property<int>("locationTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("locationTypeId"));

                    b.Property<string>("locationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("locationTypeId");

                    b.ToTable("LocationTypes");
                });

            modelBuilder.Entity("FastRouting.Repositories.Entities.TheCenterPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("centerId")
                        .HasColumnType("int");

                    b.Property<int>("floor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TheCenterPhoto");
                });

            modelBuilder.Entity("FastRouting.Repositories.Entities.Transition", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("transitionsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Transitions");
                });

            modelBuilder.Entity("FastRouting.Repositories.Entities.TransitionsToIntersections", b =>
                {
                    b.Property<int>("TransitionId")
                        .HasColumnType("int");

                    b.Property<int>("IntersectionID")
                        .HasColumnType("int");

                    b.HasKey("TransitionId", "IntersectionID");

                    b.ToTable("TransitionsToIntersections");
                });

            modelBuilder.Entity("FastRouting.Repositories.Entities.Centers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Centers");
                });

            modelBuilder.Entity("FastRouting.Repositories.Entities.Intersections", b =>
                {
                    b.HasOne("FastRouting.Repositories.Entities.Coordinate", "Coordinate")
                        .WithMany()
                        .HasForeignKey("Coordinateid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coordinate");
                });

            modelBuilder.Entity("FastRouting.Repositories.Entities.Location", b =>
                {
                    b.HasOne("FastRouting.Repositories.Entities.Coordinate", "coordinate")
                        .WithMany()
                        .HasForeignKey("coordinateid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FastRouting.Repositories.Entities.LocationTypes", "locationTypes")
                        .WithMany()
                        .HasForeignKey("locationTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FastRouting.Repositories.Entities.Transition", "transitions")
                        .WithMany()
                        .HasForeignKey("transitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("coordinate");

                    b.Navigation("locationTypes");

                    b.Navigation("transitions");
                });
#pragma warning restore 612, 618
        }
    }
}
