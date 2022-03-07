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

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id).ValueGeneratedNever();

            builder.Property(g => g.Type).HasMaxLength(100).IsRequired();

            builder.HasMany(g => g.Companies)
                .WithOne(c => c.GroupType)
                .HasForeignKey(c => c.GroupTypeId);

        }
    }
}
