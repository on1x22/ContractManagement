﻿// <auto-generated />
using System;
using CMBackend.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CMBackend.Migrations
{
    [DbContext(typeof(ContractsManagementDbContext))]
    [Migration("20231104190254_Initialize")]
    partial class Initialize
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CMBackend.DAL.ContextModels.Contract", b =>
                {
                    b.Property<string>("ContractCode")
                        .HasColumnType("text")
                        .HasColumnName("contractcode");

                    b.Property<string>("Client")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("client");

                    b.Property<string>("ContractName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("contractname");

                    b.HasKey("ContractCode");

                    b.ToTable("contracts");
                });

            modelBuilder.Entity("CMBackend.DAL.ContextModels.ContractStage", b =>
                {
                    b.Property<string>("StageName")
                        .HasColumnType("text")
                        .HasColumnName("stagename");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date")
                        .HasColumnName("enddate");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date")
                        .HasColumnName("startdate");

                    b.HasKey("StageName");

                    b.ToTable("contractstages");
                });
#pragma warning restore 612, 618
        }
    }
}