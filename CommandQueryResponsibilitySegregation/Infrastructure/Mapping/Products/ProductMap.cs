using CommandQueryResponsibilitySegregation.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CommandQueryResponsibilitySegregation.Infrastructure.Mapping.Products
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));
            builder.HasKey(product => product.Id);

            builder.Property(product => product.Name).HasMaxLength(400).IsRequired();
            builder.Property(product => product.Description).HasMaxLength(400);
            builder.Property(product => product.Price).HasColumnType("decimal(18, 2)");

            base.Configure(builder);
        }
    }
}
