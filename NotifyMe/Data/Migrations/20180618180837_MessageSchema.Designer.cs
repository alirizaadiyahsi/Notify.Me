﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NotifyMe.Data;

namespace NotifyMe.Migrations
{
    [DbContext(typeof(NotifyDbContext))]
    [Migration("20180618180837_MessageSchema")]
    partial class MessageSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NotifyMe.Data.Models.Connection", b =>
                {
                    b.Property<string>("ConnectionID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Connected");

                    b.Property<DateTime>("ConnectionDate");

                    b.Property<DateTime>("DisconnectionDate");

                    b.Property<string>("UserAgent");

                    b.Property<long?>("UserId");

                    b.HasKey("ConnectionID");

                    b.HasIndex("UserId");

                    b.ToTable("Connections");
                });

            modelBuilder.Entity("NotifyMe.Data.Models.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConnectionID");

                    b.Property<string>("Content");

                    b.Property<DateTime>("Date");

                    b.Property<string>("ToUser");

                    b.HasKey("Id");

                    b.HasIndex("ConnectionID");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("NotifyMe.Data.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NotifyMe.Data.Models.Connection", b =>
                {
                    b.HasOne("NotifyMe.Data.Models.User")
                        .WithMany("Connections")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("NotifyMe.Data.Models.Message", b =>
                {
                    b.HasOne("NotifyMe.Data.Models.Connection")
                        .WithMany("Messages")
                        .HasForeignKey("ConnectionID");
                });
#pragma warning restore 612, 618
        }
    }
}
