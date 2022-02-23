using CompanyWebApi.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyWebApi.Persistence.EntityConfigurations
{
    public class AppointmentConfiguration:IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");
            builder.HasKey(a => a.Id);


            builder.Property(a => a.AppointmentDate).IsRequired();
            builder.Property(a => a.CompanyId).IsRequired();
            builder.Property(a => a.EmployeeName).HasMaxLength(100);
            builder.Property(a => a.Title).HasMaxLength(200);

        }
    }

}
