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
    internal class CompaniesConfiguration : IEntityTypeConfiguration<Companies>
    {
        public void Configure(EntityTypeBuilder<Companies> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(500);
            builder.Property(x=>x.Province).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.Address).IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.TaxOffice).IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.TaxNumber).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.CompanyType).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.District).IsRequired(false).HasMaxLength(100);
            builder.HasMany(x => x.Departments).WithOne(x => x.Companies).HasForeignKey(x => x.CompanyID);


            builder.HasData(new Companies
            {
                ID = 1,
                Name = "Şirket1",
                TaxOffice = "İstanbul Vergi Daiesi",
                TaxNumber = 111111,
                CompanyType = "Limited",
                Province = "İstanbul",
                District = "Ataşehir",
                Address = "Ataşehir-İstanbul"
            },
             new Companies
             {
                 ID = 2,
                 Name = "Şirket2",
                 TaxOffice = "Kartal Vergi Daiesi",
                 TaxNumber = 111122,
                 CompanyType = "Limited",
                 Province = "İstanbul",
                 District = "Kartal",
                 Address = "Kartal-İstanbul"
             }
             );

        }
    }
}
