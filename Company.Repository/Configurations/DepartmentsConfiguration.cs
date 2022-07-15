using Company.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Configurations
{
    internal class DepartmentsConfiguration : IEntityTypeConfiguration<Departments>
    {
        public void Configure(EntityTypeBuilder<Departments> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(500);
            builder.HasOne(x => x.Companies).WithMany(x => x.Departments).HasForeignKey(x => x.CompanyID);
            builder.HasMany(x => x.Subdepartments).WithOne(x => x.Departments).HasForeignKey(x => x.DepartmentsId);
            builder.HasMany(x => x.TopDepartments).WithOne(x => x.Departments).HasForeignKey(x => x.DepartmentsId);

            builder.HasData(new Departments
            {
                ID = 1,
                Name = "Departman1",
                CompanyID = 1,

            },
             new Departments
             {
                 ID = 2,
                 Name = "Departman2",
                 CompanyID = 2,
             }
             ); ;
        }
    }
}
