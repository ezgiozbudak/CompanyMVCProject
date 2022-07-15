using Company.Core;
using Company.Core.Repositories;
using Company.Repository.AppDbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class CompanyRepository : GenericRepository<Companies>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Companies>> GetApiAllCompaniesAsync()
        {
            return await _context.Companies.Include(x => x.Departments).ToListAsync();
        }

        public async Task<List<Companies>> GetWebAllCompanyAsync()
        {
            return await _context.Companies.Include(x => x.Departments).ToListAsync();
        }
    }
}
