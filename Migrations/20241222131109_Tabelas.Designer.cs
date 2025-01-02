﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PicPay.Context;

#nullable disable

namespace PicPay.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20241222131109_Tabelas")]
    partial class Tabelas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PicPay.Mondels.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DestinatarioId")
                        .HasColumnType("int");

                    b.Property<int>("RemetenteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dataTransacao")
                        .HasColumnType("datetime(6)");

                    b.Property<float>("valorDaTransacao")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DestinatarioId");

                    b.HasIndex("RemetenteId");

                    b.ToTable("Transacoes");
                });

            modelBuilder.Entity("PicPay.Mondels.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PrimeiroNome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("Saldo")
                        .HasColumnType("float");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("userType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PicPay.Mondels.Transacao", b =>
                {
                    b.HasOne("PicPay.Mondels.Usuario", "destinatario")
                        .WithMany("TransacoesComoDestinatario")
                        .HasForeignKey("DestinatarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PicPay.Mondels.Usuario", "remetente")
                        .WithMany("TransacoesComoRemetente")
                        .HasForeignKey("RemetenteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("destinatario");

                    b.Navigation("remetente");
                });

            modelBuilder.Entity("PicPay.Mondels.Usuario", b =>
                {
                    b.Navigation("TransacoesComoDestinatario");

                    b.Navigation("TransacoesComoRemetente");
                });
#pragma warning restore 612, 618
        }
    }
}
