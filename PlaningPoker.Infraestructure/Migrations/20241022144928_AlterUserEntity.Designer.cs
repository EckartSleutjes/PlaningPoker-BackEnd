﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PlaningPoker.Infraestructure;

#nullable disable

namespace PlaningPoker.Infraestructure.Migrations
{
    [DbContext(typeof(PlaningPokerContext))]
    [Migration("20241022144928_AlterUserEntity")]
    partial class AlterUserEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PlaningPoker.Domain.Entity.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("PlaningPoker.Domain.Entity.Poker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Poker");
                });

            modelBuilder.Entity("PlaningPoker.Domain.Entity.PokerItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PokerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PokerId");

                    b.ToTable("PokerItem");
                });

            modelBuilder.Entity("PlaningPoker.Domain.Entity.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PokerItems")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("PlaningPoker.Domain.Entity.Storie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Played")
                        .HasColumnType("boolean");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Storie");
                });

            modelBuilder.Entity("PlaningPoker.Domain.Entity.StoriePlayer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<bool>("Flip")
                        .HasColumnType("boolean");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uuid");

                    b.Property<string>("PokerItem")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("StorieId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("StorieId");

                    b.ToTable("StoriePlayer");
                });

            modelBuilder.Entity("PlaningPoker.Domain.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PlaningPoker.Domain.Entity.Player", b =>
                {
                    b.HasOne("PlaningPoker.Domain.Entity.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("PlaningPoker.Domain.Entity.PokerItem", b =>
                {
                    b.HasOne("PlaningPoker.Domain.Entity.Poker", "Poker")
                        .WithMany("PokerItems")
                        .HasForeignKey("PokerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poker");
                });

            modelBuilder.Entity("PlaningPoker.Domain.Entity.Storie", b =>
                {
                    b.HasOne("PlaningPoker.Domain.Entity.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("PlaningPoker.Domain.Entity.StoriePlayer", b =>
                {
                    b.HasOne("PlaningPoker.Domain.Entity.Player", "Player")
                        .WithMany("StoriePlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlaningPoker.Domain.Entity.Storie", "Storie")
                        .WithMany()
                        .HasForeignKey("StorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Storie");
                });

            modelBuilder.Entity("PlaningPoker.Domain.Entity.Player", b =>
                {
                    b.Navigation("StoriePlayers");
                });

            modelBuilder.Entity("PlaningPoker.Domain.Entity.Poker", b =>
                {
                    b.Navigation("PokerItems");
                });
#pragma warning restore 612, 618
        }
    }
}