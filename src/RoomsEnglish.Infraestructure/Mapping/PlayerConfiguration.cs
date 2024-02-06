using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using RoomsEnglish.Domain.PlayerContext.Entities;

namespace RoomsEnglish.Infraestructure.Mapping
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("PLAYERS");

            builder.HasKey(user => user.Id);

            builder.Property(user => user.Email)
                .IsRequired()
                .HasColumnName("USER_EMAIL")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasConversion(p => p.Address, dbValue => dbValue);

            builder.Property(user => user.Password)
                .IsRequired()
                .HasColumnName("USER_PASSWORD")
                .HasColumnType("varchar")
                .HasMaxLength(120);

            builder.Property(user => user.Name)
                .IsRequired()
                .HasColumnName("PLAYER_NAME")
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(user => user.Experience)
                .IsRequired()
                .HasColumnName("PLAYER_EXPERIENCE")
                .HasDefaultValue(0)
                .HasMaxLength(5);

            builder.Property(user => user.Level)
                .IsRequired()
                .HasColumnName("PLAYER_LEVEL")
                .HasDefaultValue(1)
                .HasMaxLength(5);

            builder.HasIndex(user => user.Email, "IX_PLAYERS_EMAIL")
            .IsUnique();
        }
    }
}