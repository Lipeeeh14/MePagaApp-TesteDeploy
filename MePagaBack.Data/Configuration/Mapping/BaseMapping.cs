using MePagaBack.Domain.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MePagaBack.Data.Configuration.Mapping;

public class BaseMapping<T> : IEntityTypeConfiguration<T>
    where T : BaseModel
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.DataCriacao)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(x => x.DataAtualizacao)
            .HasColumnType("datetime2")
            .IsRequired(false);
    }
}
