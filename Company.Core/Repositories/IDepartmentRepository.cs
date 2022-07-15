using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Repositories
{
    public interface IDepartmentRepository :IGenericRepository<Departments>
    {
        Task<List<Departments>> GetApiAllDepartmentsAsync();
        Task<List<Departments>> GetWebAllDepartmentsAsync();
    }
}
