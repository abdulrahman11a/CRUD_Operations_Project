using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static DAL.Entities.Department;
namespace DAL.Presistance.DATA.Configurations.Department
{
    public class ConfiguraDepartmen : IEntityTypeConfiguration<Entities.Department>
    {
        public void Configure(EntityTypeBuilder<Entities.Department> builder)
        {
        
          builder.Property(D => D.Id).UseIdentityColumn();
          
            builder.Property(D => D.Name).HasColumnType("nvarchar(50)").IsRequired().HasMaxLength(50);
           
            builder.Property(D => D.Description).HasColumnType("nvarchar(128)").HasMaxLength(128);

            builder.Property(d => d.Code)
                 .HasColumnType("nvarchar(10)")
                 .IsRequired()
                 .HasDefaultValueSql("CONCAT('Dep', NEXT VALUE FOR DepartmentCodeSequence)");
            builder.Property(D => D.LastModifiedOn).HasComputedColumnSql("GetDate()");
            //Will be Execute always be if Update column in Database
            builder.Property(D => D.CreatedOn).HasDefaultValueSql("GetUTCDate()");


            builder.HasMany(D => D.Employees).WithOne(D => D.Department)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);//This if Delete fornkey in class  Employee set A Null 
        }
    }
}
