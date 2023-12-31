﻿// <auto-generated />
using System;
using CadastroDeContratoFCVS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CadastroDeContratoFCVS.Migrations
{
    [DbContext(typeof(CadastroDeContratoFCVSContext))]
    [Migration("20230715001925_segundo")]
    partial class segundo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CadastroDeContratoFCVS.Models.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("ArquivoPdf")
                        .HasColumnType("longblob");

                    b.Property<DateTime>("DataAssinatura")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NomeCliente")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<int>("NumeroContrato")
                        .HasColumnType("int");

                    b.Property<double>("ValorContrato")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Contrato");
                });
#pragma warning restore 612, 618
        }
    }
}
