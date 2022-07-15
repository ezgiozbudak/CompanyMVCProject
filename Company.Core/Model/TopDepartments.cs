using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core
{
    public class TopDepartments
    {
        public int ID { get; set; }
        [DisplayName("Üst Departman Adı")]
        public string Name { get; set; }
        public int DepartmentsId { get; set; }
        public Departments? Departments { get; set; }
        public int CompanyId { get; set; }
        public Companies? Companies { get; set; }
    }
}
