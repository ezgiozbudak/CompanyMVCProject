using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Repositories
{
    public interface ITopDepartmentRepository : IGenericRepository<TopDepartments>
    {
        Task<List<TopDepartments>> GetApiAllTopDepartmentsAsync();
        Task<List<TopDepartments>> GetWebAllTopDepartmentsAsync();
    }
}
