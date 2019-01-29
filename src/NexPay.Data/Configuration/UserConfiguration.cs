using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexPay.Domain.Entities;

namespace NexPay.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.ToTable("Usuario");

            modelBuilder.HasKey(x => x.Id);

            modelBuilder.Property(x => x.Id)
                        .HasColumnName("id");

            modelBuilder.Property(x => x.Name)
                        .HasColumnName("nome")
                        .HasMaxLength(128);

            modelBuilder.Property(x => x.Cnpj)
                        .HasColumnName("cnpj")
                        .HasMaxLength(14);


        }
    }
}