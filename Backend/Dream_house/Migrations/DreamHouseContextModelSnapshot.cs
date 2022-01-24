﻿// <auto-generated />
using System;
using Dream_house.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dream_house.Migrations
{
    [DbContext(typeof(DreamHouseContext))]
    partial class DreamHouseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Dream_house.Models.DecorationIdea", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Idea_description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DecorationIdea");
                });

            modelBuilder.Entity("Dream_house.Models.Home", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Home");
                });

            modelBuilder.Entity("Dream_house.Models.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("HomeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Home_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HomeId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("Dream_house.Models.Room_DecorationIdea", b =>
                {
                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DecorationIdeaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoomId", "DecorationIdeaId");

                    b.HasIndex("DecorationIdeaId");

                    b.ToTable("Room_DecorationIdea");
                });

            modelBuilder.Entity("Dream_house.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Dream_house.Models.Home", b =>
                {
                    b.HasOne("Dream_house.Models.User", "User")
                        .WithOne("Home")
                        .HasForeignKey("Dream_house.Models.Home", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dream_house.Models.Room", b =>
                {
                    b.HasOne("Dream_house.Models.Home", "Home")
                        .WithMany("Rooms")
                        .HasForeignKey("HomeId");

                    b.Navigation("Home");
                });

            modelBuilder.Entity("Dream_house.Models.Room_DecorationIdea", b =>
                {
                    b.HasOne("Dream_house.Models.DecorationIdea", "DecorationIdea")
                        .WithMany("Room_DecorationIdeas")
                        .HasForeignKey("DecorationIdeaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dream_house.Models.Room", "Room")
                        .WithMany("Room_DecorationIdeas")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DecorationIdea");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Dream_house.Models.DecorationIdea", b =>
                {
                    b.Navigation("Room_DecorationIdeas");
                });

            modelBuilder.Entity("Dream_house.Models.Home", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Dream_house.Models.Room", b =>
                {
                    b.Navigation("Room_DecorationIdeas");
                });

            modelBuilder.Entity("Dream_house.Models.User", b =>
                {
                    b.Navigation("Home");
                });
#pragma warning restore 612, 618
        }
    }
}
