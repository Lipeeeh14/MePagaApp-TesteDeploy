using MePagaBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MePagaBack.Data.Configuration.Mapping;

public class DividaMapping : BaseMapping<Divida>
{
    public override void Configure(EntityTypeBuilder<Divida> builder) 
    {
        base.Configure(builder);

        builder.Property(x => x.Valor)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.Quitada)
            .IsRequired();
    }
}
