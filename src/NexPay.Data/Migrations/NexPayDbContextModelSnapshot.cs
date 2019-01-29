﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NexPay.Data.Context;

namespace NexPay.Data.Migrations
{
    [DbContext(typeof(NexPayDbContext))]
    partial class NexPayDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("NexPay.Domain.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("TransactionType")
                        .HasColumnName("tipo")
                        .HasMaxLength(4);

                    b.Property<int>("UserId")
                        .HasColumnName("usuario_id");

                    b.Property<decimal>("Value")
                        .HasColumnName("status")
                        .HasColumnType("numeric[15,2]")
                        .HasMaxLength(12);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Transferencia");
                });

            modelBuilder.Entity("NexPay.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Cnpj")
                        .HasColumnName("cnpj")
                        .HasMaxLength(14);

                    b.Property<string>("Name")
                        .HasColumnName("nome")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("NexPay.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("NexPay.Domain.Entities.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("NexPay.Domain.ValueObjects.Person", "Beneficiary", b1 =>
                        {
                            b1.Property<int>("TransactionId");

                            b1.Property<string>("Account")
                                .HasColumnName("beneficiario_conta")
                                .HasMaxLength(6);

                            b1.Property<string>("Agency")
                                .HasColumnName("beneficiario_agencia")
                                .HasMaxLength(4);

                            b1.Property<string>("Bank")
                                .HasColumnName("beneficiario_banco")
                                .HasMaxLength(3);

                            b1.Property<string>("Name")
                                .HasColumnName("beneficiario_nome")
                                .HasMaxLength(128);

                            b1.HasKey("TransactionId");

                            b1.ToTable("Transferencia");

                            b1.HasOne("NexPay.Domain.Entities.Transaction")
                                .WithOne("Beneficiary")
                                .HasForeignKey("NexPay.Domain.ValueObjects.Person", "TransactionId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("NexPay.Domain.ValueObjects.Person", "Payer", b1 =>
                        {
                            b1.Property<int>("TransactionId");

                            b1.Property<string>("Account")
                                .HasColumnName("pagador_conta")
                                .HasMaxLength(6);

                            b1.Property<string>("Agency")
                                .HasColumnName("pagador_agencia")
                                .HasMaxLength(4);

                            b1.Property<string>("Bank")
                                .HasColumnName("pagador_banco")
                                .HasMaxLength(3);

                            b1.Property<string>("Name")
                                .HasColumnName("pagador_nome")
                                .HasMaxLength(128);

                            b1.HasKey("TransactionId");

                            b1.ToTable("Transferencia");

                            b1.HasOne("NexPay.Domain.Entities.Transaction")
                                .WithOne("Payer")
                                .HasForeignKey("NexPay.Domain.ValueObjects.Person", "TransactionId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
