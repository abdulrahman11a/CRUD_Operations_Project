using DAL.CommonEnum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Presistance.DATA.Configurations.Employee
{
    internal class EmployeeConfigration : IEntityTypeConfiguration<Entities.Employee>
    {
        public void Configure(EntityTypeBuilder<Entities.Employee> builder)
        {
            builder.Property(e => e.Name)
                .HasColumnType("Varchar(50)")
                .IsRequired();

            builder.Property(e => e.Address)
                .HasColumnType("Varchar(100)");

            builder.Property(e => e.Salary)
                .HasColumnType("decimal(8,2)");

            builder.Property(e => e.Gender)
                .HasConversion(
                    gender => gender.ToString(),
                    genderString => (Gender)Enum.Parse(typeof(Gender), genderString)
                );

            builder.Property(e => e.EmpType)
                .HasConversion(
                    type => type.ToString(),
                    typeString => (EmployeeType)Enum.Parse(typeof(EmployeeType), typeString)
                );

            builder.Property(e => e.CreatedOn)
                .HasDefaultValueSql("GetUTCDate()");
        }
    }
}
