using CompanyWebApi.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyWebApi.Persistence.EntityConfigurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.CreationDate).IsRequired();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);



            builder.HasMany(c => c.Orders);
            builder.HasMany(c => c.Appointments);
            builder.HasOne(c => c.GroupType);
        }
    }
}
