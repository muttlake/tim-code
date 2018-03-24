﻿// <auto-generated />
using AdventureWorks.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AdventureWorks.Client.Migrations
{
    [DbContext(typeof(PersonContext))]
    [Migration("20180323190116_FirstCommitg")]
    partial class FirstCommitg
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdventureWorks.Library.Models.Name", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("First");

                    b.Property<string>("Last");

                    b.HasKey("Id");

                    b.ToTable("Name");
                });

            modelBuilder.Entity("AdventureWorks.Library.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("NameId");

                    b.HasKey("Id");

                    b.HasIndex("NameId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("AdventureWorks.Library.Models.Person", b =>
                {
                    b.HasOne("AdventureWorks.Library.Models.Name", "Name")
                        .WithMany()
                        .HasForeignKey("NameId");
                });
#pragma warning restore 612, 618
        }
    }
}
