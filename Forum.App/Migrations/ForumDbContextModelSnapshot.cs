﻿// <auto-generated />
using System;
using Forum.App.DataBase.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Forum.App.Migrations
{
    [DbContext(typeof(ForumDbContext))]
    partial class ForumDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Forum.App.DataBase.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ParentId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Forum.App.DataBase.Entities.Subforum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Forums");
                });

            modelBuilder.Entity("Forum.App.DataBase.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("SubforumId");

                    b.HasKey("Id");

                    b.HasIndex("SubforumId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Forum.App.DataBase.Entities.Message", b =>
                {
                    b.HasOne("Forum.App.DataBase.Entities.Subject", "Parent")
                        .WithMany("Messages")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Forum.App.DataBase.Entities.Subject", b =>
                {
                    b.HasOne("Forum.App.DataBase.Entities.Subforum")
                        .WithMany("Subjects")
                        .HasForeignKey("SubforumId");
                });
#pragma warning restore 612, 618
        }
    }
}
