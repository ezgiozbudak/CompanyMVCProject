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
    internal class SubdepartmentsConfiguration : IEntityTypeConfiguration<Subdepartments>
    {
        public void Configure(EntityTypeBuilder<Subdepartments> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired(false).HasMaxLength(500);
            builder.HasOne(x => x.Departments).WithMany(x => x.Subdepartments).HasForeignKey(x => x.DepartmentsId);

            builder.HasData(new Subdepartments
            {
                ID = 1,
                Name = "AltD1",
                DepartmentsId = 1,

            },
            new Subdepartments
            {
                ID = 2,
                Name = "AltD2",
                DepartmentsId = 2,
            },
             new Subdepartments
             {
                 ID = 3,
                 Name = "AltD3",
                 DepartmentsId = 1,
             },
              new Subdepartments
              {
                  ID = 4,
                  Name = "AltD4",
                  DepartmentsId = 2,
              }
            );

        }
    }
}
