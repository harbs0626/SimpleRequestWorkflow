﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleRequestWorkflow.Models;

namespace SimpleRequestWorkflow.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200420004044_Second")]
    partial class Second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimpleRequestWorkflow.Models.TransactionType", b =>
                {
                    b.Property<int>("TransactionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDateTime");

                    b.Property<string>("Code");

                    b.Property<decimal>("MaximumLimit");

                    b.Property<decimal>("MinimumLimit");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDateTime");

                    b.Property<string>("Title");

                    b.HasKey("TransactionTypeId");

                    b.ToTable("TransactionTypes");
                });

            modelBuilder.Entity("SimpleRequestWorkflow.Models.Workflow", b =>
                {
                    b.Property<int>("WorkflowId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProcessedBy");

                    b.Property<DateTime>("ProcessedDateTime");

                    b.Property<string>("Remarks")
                        .IsRequired();

                    b.Property<string>("RequestStatus");

                    b.Property<string>("RequestedBy");

                    b.Property<DateTime>("RequestedDateTime");

                    b.Property<string>("Requestor")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<double>("TransactionAmount");

                    b.Property<string>("TransactionType")
                        .IsRequired();

                    b.HasKey("WorkflowId");

                    b.ToTable("Workflows");
                });
#pragma warning restore 612, 618
        }
    }
}
