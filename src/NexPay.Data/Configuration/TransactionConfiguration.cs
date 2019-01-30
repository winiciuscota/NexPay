using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexPay.Domain.Entities;

namespace NexPay.Data.Configuration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> modelBuilder)
        {
            modelBuilder.ToTable("Transferencia");

            // Keys
            modelBuilder.HasKey(x => x.Id);

            modelBuilder.HasOne(x => x.User)
                        .WithMany(x => x.Transactions)
                        .HasForeignKey(x => x.UserId);

            // Owned tables

            modelBuilder.OwnsOne(x => x.Payer, owned =>
            {
                owned.Property(x => x.Account)
                    .HasColumnName("pagador_conta")
                    .HasMaxLength(6);

                owned.Property(x => x.Name)
                    .HasColumnName("pagador_nome")
                    .HasMaxLength(128);

                owned.Property(x => x.Bank)
                    .HasColumnName("pagador_banco")
                    .HasMaxLength(3);

                owned.Property(x => x.Agency)
                    .HasColumnName("pagador_agencia")
                    .HasMaxLength(4);
            });

            modelBuilder.OwnsOne(x => x.Beneficiary, owned =>
            {
                owned.Property(x => x.Account)
                    .HasColumnName("beneficiario_conta")
                    .HasMaxLength(6);

                owned.Property(x => x.Name)
                    .HasColumnName("beneficiario_nome")
                    .HasMaxLength(128);

                owned.Property(x => x.Bank)
                    .HasColumnName("beneficiario_banco")
                    .HasMaxLength(3);

                owned.Property(x => x.Agency)
                    .HasColumnName("beneficiario_agencia")
                    .HasMaxLength(4);
            });

            modelBuilder.Property(x => x.Value)
                        .HasColumnName("valor")
                        .HasColumnType("numeric[15,2]");

            modelBuilder.Property(x => x.TransactionType)
                        .HasColumnName("tipo")
                        .HasMaxLength(4);

            modelBuilder.Property(x => x.Value)
                        .HasColumnName("status")
                        .HasMaxLength(12);


            modelBuilder.Property(x => x.Id)
                        .HasColumnName("id");

            modelBuilder.Property(x => x.UserId)
                        .HasColumnName("usuario_id");

            modelBuilder.HasQueryFilter(x => !x.Deleted);
        }
    }
}