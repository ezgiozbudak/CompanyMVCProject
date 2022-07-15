using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Repositories
{
    public interface ISubdepartmentRepository : IGenericRepository<Subdepartments>
    {
        Task<List<Subdepartments>> GetApiAllSubdepartmentsAsync();
        Task<List<Subdepartments>> GetWebAllSubdepartmentsAsync();
        
    }
}
