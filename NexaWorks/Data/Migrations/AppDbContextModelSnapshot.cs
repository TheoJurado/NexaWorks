﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NexaWorks.Data;

#nullable disable

namespace NexaWorks.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NexaWorks.Models.OS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OSs");
                });

            modelBuilder.Entity("NexaWorks.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("NexaWorks.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssociatedVersionOSId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DateCreat")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DateResolve")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsResolved")
                        .HasColumnType("bit");

                    b.Property<string>("ResolveDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssociatedVersionOSId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("NexaWorks.Models.Version", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NumVersion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductKeyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductKeyId");

                    b.ToTable("Versions");
                });

            modelBuilder.Entity("NexaWorks.Models.Version_OS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OSKeyId")
                        .HasColumnType("int");

                    b.Property<int>("VersionKeyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OSKeyId");

                    b.HasIndex("VersionKeyId");

                    b.ToTable("Targets");
                });

            modelBuilder.Entity("NexaWorks.Models.Ticket", b =>
                {
                    b.HasOne("NexaWorks.Models.Version_OS", "AssociatedVersionOSKey")
                        .WithMany("Tickets")
                        .HasForeignKey("AssociatedVersionOSId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssociatedVersionOSKey");
                });

            modelBuilder.Entity("NexaWorks.Models.Version", b =>
                {
                    b.HasOne("NexaWorks.Models.Product", "ProductKey")
                        .WithMany("Versions")
                        .HasForeignKey("ProductKeyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductKey");
                });

            modelBuilder.Entity("NexaWorks.Models.Version_OS", b =>
                {
                    b.HasOne("NexaWorks.Models.OS", "OSKey")
                        .WithMany("AssociatedVersionOS")
                        .HasForeignKey("OSKeyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NexaWorks.Models.Version", "VersionKey")
                        .WithMany("AssociatedVersionOS")
                        .HasForeignKey("VersionKeyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OSKey");

                    b.Navigation("VersionKey");
                });

            modelBuilder.Entity("NexaWorks.Models.OS", b =>
                {
                    b.Navigation("AssociatedVersionOS");
                });

            modelBuilder.Entity("NexaWorks.Models.Product", b =>
                {
                    b.Navigation("Versions");
                });

            modelBuilder.Entity("NexaWorks.Models.Version", b =>
                {
                    b.Navigation("AssociatedVersionOS");
                });

            modelBuilder.Entity("NexaWorks.Models.Version_OS", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}