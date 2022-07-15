using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core
{
    public class Companies
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [DisplayName("Şirket Adı")]
        public string? Name { get; set; }
        [DisplayName("Şirket Türü")]
        public string? CompanyType { get; set; }
        [DisplayName("Vergi Dairesi")]
        public string? TaxOffice { get; set; }
        [DisplayName("Vergi Numarası")]
        public int? TaxNumber { get; set; }
        [DisplayName("İl")]
        public string? Province { get; set; }
        [DisplayName("İlçe")]
        public string? District{ get; set; }
        [DisplayName("Adres")]
        public string? Address { get; set; }

        public ICollection<Departments>? Departments { get; set; }
        public ICollection<TopDepartments>? TopDepartments { get; set; }
        public ICollection<Subdepartments>? Subdepartments { get; set; }
    }
}
