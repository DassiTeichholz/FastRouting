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
    [Migration("20230313160131_migration3")]
    partial class migration3
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.Property<int>("Z")
                        .HasColumnType("int");

                    b.HasKey("Id");

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

                    b.Property<int>("CoordinateId")
                        .HasColumnType("int");

                    b.Property<int>("centerId")
                        .HasColumnType("int");

                    b.HasKey("IntersectionID");

                    b.HasIndex("CoordinateId");

                    b.ToTable("Intersections");
                });

            modelBuilder.Entity("FastRouting.Repositories.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CoordinateId")
                        .HasColumnType("int");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationTypesId")
                        .HasColumnType("int");

                    b.Property<int>("TransitionId")
                        .HasColumnType("int");

                    b.Property<int>("centerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoordinateId");

                    b.HasIndex("LocationTypesId");

                    b.HasIndex("TransitionId");

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

            modelBuilder.Entity("FastRouting.Repositories.Entities.TheMallPhotos", b =>
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

                    b.ToTable("TheMallPhotos");
                });

            modelBuilder.Entity("FastRouting.Repositories.Entities.Transition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TransitionsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

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

            modelBuilder.Entity("FastRouting.Repositories.Entities.shoppingMalls", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("shoppingMalls");
                });

            modelBuilder.Entity("FastRouting.Repositories.Entities.Intersections", b =>
                {
                    b.HasOne("FastRouting.Repositories.Entities.Coordinate", "Coordinate")
                        .WithMany()
                        .HasForeignKey("CoordinateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coordinate");
                });

            modelBuilder.Entity("FastRouting.Repositories.Entities.Location", b =>
                {
                    b.HasOne("FastRouting.Repositories.Entities.Coordinate", "Coordinate")
                        .WithMany()
                        .HasForeignKey("CoordinateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FastRouting.Repositories.Entities.LocationTypes", "LocationTypes")
                        .WithMany()
                        .HasForeignKey("LocationTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FastRouting.Repositories.Entities.Transition", "Transition")
                        .WithMany()
                        .HasForeignKey("TransitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coordinate");

                    b.Navigation("LocationTypes");

                    b.Navigation("Transition");
                });
#pragma warning restore 612, 618
        }
    }
}
