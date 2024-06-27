using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class TrophyConfiguration : IEntityTypeConfiguration<Trophy>
    {
        public void Configure(EntityTypeBuilder<Trophy> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Competition).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Year).IsRequired();

            builder
                .HasOne(comp => comp.Club)
                .WithMany(club => club.Tropies)
                .HasPrincipalKey(c => c.Id)
                .HasForeignKey(p => p.ClubId);
        }
    }
}
