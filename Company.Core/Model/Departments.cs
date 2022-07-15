using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core
{
    public class Departments
    {
        public int ID { get; set; }
        [DisplayName("Departman Adı")]
        public string? Name { get; set; }
        [DisplayName("Şirket ID")]
        public int CompanyID { get; set; }
        public Companies Companies { get; set; }

        public  ICollection<Subdepartments>? Subdepartments { get; set; }
        public ICollection<TopDepartments>? TopDepartments { get; set; }

    }
}
