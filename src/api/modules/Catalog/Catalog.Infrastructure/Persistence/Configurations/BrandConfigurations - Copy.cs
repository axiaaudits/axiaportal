using Finbuckle.MultiTenant;
using FSH.Starter.WebApi.Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Persistence.Configurations;
internal sealed class FirmConfiguration : IEntityTypeConfiguration<Firm>
{
    public void Configure(EntityTypeBuilder<Firm> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);  // Assuming Firm has an Id property

        builder.Property(x => x.FirmName).HasMaxLength(200);  // Set a max length for FirmName
        builder.Property(x => x.PostalAddress).HasMaxLength(500);  // Set a max length for PostalAddress
        builder.Property(x => x.Suburb).HasMaxLength(100);  // Set a max length for Suburb
        builder.Property(x => x.State).HasMaxLength(100);  // Set a max length for State
        builder.Property(x => x.PostalCode).HasMaxLength(20);  // Set a max length for PostalCode
        builder.Property(x => x.Fascimile).HasMaxLength(50);  // Set a max length for Fascimile
        builder.Property(x => x.Phone).HasMaxLength(50);  // Set a max length for Phone
        builder.Property(x => x.FirmCode).HasMaxLength(50);  // Set a max length for FirmCode
    }
}
