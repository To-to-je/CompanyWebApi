using CompanyWebApi.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyWebApi.Persistence.EntityConfigurations
{
    public class GroupTypeConfiguration:IEntityTypeConfiguration<GroupType>
    {
        public void Configure(EntityTypeBuilder<GroupType> builder)
        {
            builder.ToTable("GroupTypes");

            builder.Property(g => g.Type).HasMaxLength(100).IsRequired();

            builder.HasMany(g => g.Company)
                .WithOne(c => c.GroupType);
        }
    }
}
