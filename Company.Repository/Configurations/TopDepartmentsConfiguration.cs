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
    internal class TopDepartmentsConfiguration : IEntityTypeConfiguration<TopDepartments>
    {
        public void Configure(EntityTypeBuilder<TopDepartments> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired(false).HasMaxLength(500);
            builder.HasOne(x => x.Departments).WithMany(x => x.TopDepartments).HasForeignKey(x => x.DepartmentsId);

            builder.HasData(new TopDepartments
            {
                ID = 1,
                Name = "ÜstD1",
                DepartmentsId = 1,

            },
            new TopDepartments
            {
                ID = 2,
                Name = "ÜstD2",
                DepartmentsId = 1,
            },
             new TopDepartments
             {
                 ID = 3,
                 Name = "ÜstD3",
                 DepartmentsId = 2,
             },
              new TopDepartments
              {
                  ID = 4,
                  Name = "ÜstD4",
                  DepartmentsId = 2,
              }
            );
        }
    }
}
