using System.ComponentModel.DataAnnotations.Schema;
using CompanyWebApi.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyWebApi.Persistence.EntityConfigurations
{
    public class ProductConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductCode);
            builder.Property(p => p.ProductCode).ValueGeneratedNever();

            builder.Property(p => p.Name).HasMaxLength(200)
                .IsRequired();

            builder.HasMany(p => p.Orders)
                .WithOne(o => o.Product)
                .HasForeignKey(o=>o.ProductId);
        }
    }
}
