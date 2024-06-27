using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Height).IsRequired();
            builder.Property(x => x.Position).HasMaxLength(20).IsRequired();
            builder.Property(x => x.DateBirth).IsRequired();

            builder
                .HasOne(p => p.Club)
                .WithMany(c => c.Players)
                .HasPrincipalKey(c => c.Id)
                .HasForeignKey(p => p.ClubId);
        }
    }
}
