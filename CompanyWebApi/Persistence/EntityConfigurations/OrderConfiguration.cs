using CompanyWebApi.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyWebApi.Persistence.EntityConfigurations
{
    public class OrderConfiguration:IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.HasKey(o => o.OrderId);


            builder.Property(c => c.CompanyId).IsRequired();
            builder.Property(o => o.DateOfOrder).IsRequired();
            builder.Property(o => o.OrderId).ValueGeneratedNever();


            builder.HasOne(o => o.Company)
                .WithMany(c => c.Orders);
            builder.HasOne(c => c.Product)
                .WithMany(p => p.Orders);

        }
    }
}
