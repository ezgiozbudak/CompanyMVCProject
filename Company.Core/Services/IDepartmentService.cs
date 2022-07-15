using Company.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Services
{
    public interface IDepartmentService : IGenericService<Departments>
    {
        Task<CustomResponseDto<List<DepartmentsDto>>> GetApiAllDepartments();
        Task<List<DepartmentsDto>> GetWebAllDepartments();
    }
}
