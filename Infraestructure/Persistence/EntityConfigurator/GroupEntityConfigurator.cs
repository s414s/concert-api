using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.EntityConfigurator;

public class GroupEntityConfigurator : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Genre)
            .IsRequired()
            .HasConversion<string>();

        builder
            .HasMany(x => x.EventGroups)
            .WithOne(x => x.Group)
            .HasForeignKey(b => b.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
