using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace RoomsEnglish.Infraestructure.Mapping
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Domain.UserContext.Entities.Player>
    {
        public void Configure(EntityTypeBuilder<Domain.UserContext.Entities.Player> builder)
        {
            builder.ToTable("PLAYERS");

            builder.HasKey(user => user.Id);

            builder.Property(user => user.Email)
                .IsRequired()
                .HasColumnName("USER_EMAIL")
                .HasMaxLength(30);

            builder.Property(user => user.Password)
                .IsRequired()
                .HasColumnName("USER_PASSWORD")
                .HasMaxLength(80);

            builder.Property(user => user.Name)
                .IsRequired()
                .HasColumnName("PLAYER_NAME")
                .HasMaxLength(30);

            builder.Property(user => user.Experience)
                .IsRequired()
                .HasColumnName("PLAYER_EXPERIENCE")
                .HasMaxLength(5);

            builder.Property(user => user.Level)
                .IsRequired()
                .HasColumnName("PLAYER_LEVEL")
                .HasMaxLength(5);
        }
    }
}