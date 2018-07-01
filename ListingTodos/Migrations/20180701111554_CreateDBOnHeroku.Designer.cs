﻿// <auto-generated />
using ListingTodos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ListingTodos.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20180701111554_CreateDBOnHeroku")]
    partial class CreateDBOnHeroku
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("ListingTodos.Models.Todo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedOn");

                    b.Property<DateTimeOffset?>("DueOn");

                    b.Property<bool>("IsDone");

                    b.Property<bool>("IsUrgent");

                    b.Property<string>("Title");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("ListingTodos.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ListingTodos.Models.Todo", b =>
                {
                    b.HasOne("ListingTodos.Models.User", "User")
                        .WithMany("Todos")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
