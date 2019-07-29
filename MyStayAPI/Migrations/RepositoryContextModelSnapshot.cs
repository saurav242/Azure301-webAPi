﻿// <auto-generated />
using System;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MyStayAPI.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate");

                    b.Property<int>("ConsumerId");

                    b.Property<DateTime>("EndDate");

                    b.Property<int?>("HotelId");

                    b.Property<int>("HotelRoomId");

                    b.Property<int>("NumberOfRoom");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("ConsumerId");

                    b.HasIndex("HotelId");

                    b.HasIndex("HotelRoomId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("Entity.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<bool>("AirConditioning");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<bool>("FreeParking");

                    b.Property<bool>("FreeWifi");

                    b.Property<bool>("LiftAccess");

                    b.Property<string>("Name");

                    b.Property<int>("PhoneNumber");

                    b.Property<int>("PostalCode");

                    b.Property<bool>("Restaurant");

                    b.HasKey("Id");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("Entity.Models.HotelRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HotelId");

                    b.Property<int>("NumOfPeople");

                    b.Property<int>("NumberOfRoom");

                    b.Property<int>("PriceRate");

                    b.Property<string>("RoomType");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelRoom");
                });

            modelBuilder.Entity("Entity.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("Idcard");

                    b.Property<string>("LastName");

                    b.Property<string>("Nationality");

                    b.Property<string>("Password");

                    b.Property<int>("PhoneNumber");

                    b.Property<int>("PostalCode");

                    b.Property<string>("Role");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Entity.Models.Booking", b =>
                {
                    b.HasOne("Entity.Models.User", "Consumer")
                        .WithMany("Booking")
                        .HasForeignKey("ConsumerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entity.Models.Hotel")
                        .WithMany("Booking")
                        .HasForeignKey("HotelId");

                    b.HasOne("Entity.Models.HotelRoom", "HotelRoom")
                        .WithMany("Booking")
                        .HasForeignKey("HotelRoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entity.Models.HotelRoom", b =>
                {
                    b.HasOne("Entity.Models.Hotel", "Hotel")
                        .WithMany("HotelRoom")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
