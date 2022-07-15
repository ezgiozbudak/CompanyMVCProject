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
    public class DepartmentRepository : GenericRepository<Departments>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Departments>> GetApiAllDepartmentsAsync()
        {
            return await _context.Departments.Include(x => x.Companies).ToListAsync();
        }

        public async Task<List<Departments>> GetWebAllDepartmentsAsync()
        {
            return await _context.Departments.Include(x => x.Companies).ToListAsync();
        }
    }
}
