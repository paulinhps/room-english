using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RoomsEnglish.Domain.Models;
using RoomsEnglish.Domain.PlayerContext.Entities;

namespace RoomsEnglish.Infraestructure.Mapping
{
    public class ApplicationUserMap : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("USER");

            builder.HasKey(user => user.Id);

            builder.Property(user => user.Email)
                .IsRequired()
                .HasColumnName("SENHA_EMAIL")
                .HasMaxLength(30);

            builder.Property(user => user.Password)
                .IsRequired()
                .HasColumnName("SENHA_PASSWORD")
                .HasMaxLength(80);

            builder.Property(user => user.Name)
                .IsRequired()
                .HasColumnName("EMAIL_USUARIO")
                .HasMaxLength(30);

            builder.Property(user => user.Experience)
                .IsRequired()
                .HasColumnName("SENHA_EXPERIENCE")
                .HasMaxLength(5);

            builder.Property(user => user.Level)
                .IsRequired()
                .HasColumnName("SENHA_LEVEL")
                .HasMaxLength(5);
        }
    }
}