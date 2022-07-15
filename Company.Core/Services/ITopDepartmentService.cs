using Company.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Services
{
    public interface ITopDepartmentService : IGenericService<TopDepartments>
    {
        Task<CustomResponseDto<List<TopDepartmentsDto>>> GetApiAllTopDepartments();
        Task<List<TopDepartmentsDto>> GetWebAllTopDepartments();
    }
}
