using Company.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Services
{
    public interface ISubdepartmentService : IGenericService<Subdepartments>
    {
        Task<CustomResponseDto<List<SubDepartmentsDto>>> GetApiAllSubdepartments();
        Task<List<SubDepartmentsDto>> GetWebAllSubdepartments();
        
    }
}
