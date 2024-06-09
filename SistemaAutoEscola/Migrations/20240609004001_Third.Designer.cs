﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaAutoEscola.Data;

#nullable disable

namespace SistemaAutoEscola.Migrations
{
    [DbContext(typeof(SistemaAutoEscolaContext))]
    [Migration("20240609004001_Third")]
    partial class Third
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemaAutoEscola.Models.Carro", b =>
                {
                    b.Property<int>("CarroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarroId"));

                    b.Property<string>("Ano")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("JaReservado")
                        .HasColumnType("bit");

                    b.Property<string>("ModeloCarro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCarro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReservaId")
                        .HasColumnType("int");

                    b.HasKey("CarroId");

                    b.ToTable("Carro");
                });

            modelBuilder.Entity("SistemaAutoEscola.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<bool>("AprovadoDetran")
                        .HasColumnType("bit");

                    b.Property<string>("NomeCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Turma")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("SistemaAutoEscola.Models.Reserva", b =>
                {
                    b.Property<int>("ReservaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservaId"));

                    b.Property<int>("CarroId")
                        .HasColumnType("int");

                    b.Property<int?>("CarroId1")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataReserva")
                        .HasColumnType("datetime2");

                    b.HasKey("ReservaId");

                    b.HasIndex("CarroId1");

                    b.HasIndex("ClienteId");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("SistemaAutoEscola.Models.Reserva", b =>
                {
                    b.HasOne("SistemaAutoEscola.Models.Carro", "Carro")
                        .WithMany()
                        .HasForeignKey("CarroId1");

                    b.HasOne("SistemaAutoEscola.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carro");

                    b.Navigation("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
