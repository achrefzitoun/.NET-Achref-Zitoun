﻿// <auto-generated />
using System;
using AM.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    [DbContext(typeof(AMContext))]
    partial class AMContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AM.ApplicationCore.Domain.Flight", b =>
                {
                    b.Property<int>("flightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("flightId"));

                    b.Property<string>("departure")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nchar")
                        .HasDefaultValue("Tunis")
                        .HasColumnName("Depart");

                    b.Property<string>("destination")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<DateTime>("effectiveArrival")
                        .HasColumnType("date");

                    b.Property<int>("estimatedDuration")
                        .HasColumnType("int");

                    b.Property<DateTime>("flightDate")
                        .HasColumnType("date");

                    b.Property<int?>("planeFk")
                        .HasColumnType("int");

                    b.HasKey("flightId");

                    b.HasIndex("planeFk");

                    b.ToTable("MyFlight", (string)null);
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Passenger", b =>
                {
                    b.Property<string>("passportNumber")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<DateTime>("birthDate")
                        .HasColumnType("date");

                    b.Property<string>("emailAdress")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("passengerId")
                        .HasColumnType("int");

                    b.Property<string>("telNumber")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("passportNumber");

                    b.ToTable("Passengers", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Plane", b =>
                {
                    b.Property<int>("planeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("planeId"));

                    b.Property<int>("capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("manufactureDate")
                        .HasColumnType("date");

                    b.Property<int>("planeType")
                        .HasColumnType("int");

                    b.HasKey("planeId");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Ticket", b =>
                {
                    b.Property<string>("passengerFK")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("flightFK")
                        .HasColumnType("int");

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.Property<string>("Siege")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<bool>("VIP")
                        .HasColumnType("bit");

                    b.HasKey("passengerFK", "flightFK");

                    b.HasIndex("flightFK");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Staff", b =>
                {
                    b.HasBaseType("AM.ApplicationCore.Domain.Passenger");

                    b.Property<DateTime>("employementDate")
                        .HasColumnType("date");

                    b.Property<string>("function")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<float>("salary")
                        .HasColumnType("real");

                    b.ToTable("Staffs", (string)null);
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Traveller", b =>
                {
                    b.HasBaseType("AM.ApplicationCore.Domain.Passenger");

                    b.Property<string>("healthInfomation")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("nationality")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.ToTable("Travellers", (string)null);
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Flight", b =>
                {
                    b.HasOne("AM.ApplicationCore.Domain.Plane", "plane")
                        .WithMany("flights")
                        .HasForeignKey("planeFk")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("plane");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Passenger", b =>
                {
                    b.OwnsOne("AM.ApplicationCore.Domain.FullName", "FullName", b1 =>
                        {
                            b1.Property<string>("PassengerpassportNumber")
                                .HasMaxLength(120)
                                .HasColumnType("nvarchar(120)");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(120)
                                .HasColumnType("nvarchar(120)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(120)
                                .HasColumnType("nvarchar(120)");

                            b1.HasKey("PassengerpassportNumber");

                            b1.ToTable("Passengers");

                            b1.WithOwner()
                                .HasForeignKey("PassengerpassportNumber");
                        });

                    b.Navigation("FullName")
                        .IsRequired();
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Ticket", b =>
                {
                    b.HasOne("AM.ApplicationCore.Domain.Flight", "flight")
                        .WithMany("tickets")
                        .HasForeignKey("flightFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AM.ApplicationCore.Domain.Passenger", "passenger")
                        .WithMany("tickets")
                        .HasForeignKey("passengerFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("flight");

                    b.Navigation("passenger");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Staff", b =>
                {
                    b.HasOne("AM.ApplicationCore.Domain.Passenger", null)
                        .WithOne()
                        .HasForeignKey("AM.ApplicationCore.Domain.Staff", "passportNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Traveller", b =>
                {
                    b.HasOne("AM.ApplicationCore.Domain.Passenger", null)
                        .WithOne()
                        .HasForeignKey("AM.ApplicationCore.Domain.Traveller", "passportNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Flight", b =>
                {
                    b.Navigation("tickets");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Passenger", b =>
                {
                    b.Navigation("tickets");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Plane", b =>
                {
                    b.Navigation("flights");
                });
#pragma warning restore 612, 618
        }
    }
}
