using MePagaBack.Domain.Models;
using MePagaBack.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MePagaBack.Data.Configuration.Mapping;

public class DevedorMapping : BaseMapping<Devedor>
{
    public override void Configure(EntityTypeBuilder<Devedor> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.OwnsOne(x => x.Email)
            .Property(x => x.Email)
            .HasMaxLength(100)
            .HasColumnName(nameof(EmailValueObject.Email))
            .IsRequired(false);

        builder.Property(x => x.Ativa)
            .IsRequired();

        builder.HasMany(x => x.Dividas)
            .WithOne(x => x.Devedor)
            .HasForeignKey(x => x.DevedorId);
    }
}
