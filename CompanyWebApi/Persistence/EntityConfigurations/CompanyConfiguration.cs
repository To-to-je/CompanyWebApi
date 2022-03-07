using CompanyWebApi.Core.Domain;
using MessagePack.Formatters;
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
            builder.Property(c => c.GroupTypeId).IsRequired();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);


            builder.HasOne(c => c.GroupType)
                .WithMany(g => g.Companies);
            builder.HasMany(c => c.Orders)
                .WithOne(o=>o.Company)
                .HasForeignKey(o=>o.CompanyId);
            builder.HasMany(c => c.Appointments)
                .WithOne(a=>a.Company)
                .HasForeignKey(a=>a.CompanyId);
        }
    }
}
