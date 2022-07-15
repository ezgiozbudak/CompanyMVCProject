using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.DTOs
{
    public class SubDepartmentsDto : BaseDto
    {
        public string Name { get; set; }
        public int DepartmentsId { get; set; }
        public int CompanyId { get; set; }

    }
}
