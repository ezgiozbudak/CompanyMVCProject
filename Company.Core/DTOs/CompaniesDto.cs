using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.DTOs
{
    public class CompaniesDto : BaseDto
    {
        public string Name { get; set; }
        public string CompanyType { get; set; }
        public string TaxOffice { get; set; }
        public int TaxNumber { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
    }
}
