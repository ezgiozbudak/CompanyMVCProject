using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Repositories
{
    public interface ICompanyRepository :IGenericRepository<Companies>
    {
        Task<List<Companies>> GetApiAllCompaniesAsync();
        Task<List<Companies>> GetWebAllCompanyAsync();
    }
}
