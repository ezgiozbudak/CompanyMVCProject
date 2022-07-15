using Company.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Services
{
    public interface ICompanyService : IGenericService<Companies>
    {
        Task<CustomResponseDto<List<CompaniesDto>>> GetApiAllCompanies();
        Task<List<CompaniesDto>> GetWebAllCompanies();
    }
}
