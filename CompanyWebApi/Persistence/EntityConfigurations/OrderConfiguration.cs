using System.ComponentModel.DataAnnotations.Schema;
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

            
            builder.Property(o => o.DateOfOrder).IsRequired();
            builder.Property(o => o.OrderId).ValueGeneratedNever();
            

            builder.HasMany(c => c.Products);

        }
    }
}
