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
    public class SubDepartmentRepository : GenericRepository<Subdepartments>, ISubdepartmentRepository
    {
        public SubDepartmentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Subdepartments>> GetApiAllSubdepartmentsAsync()
        {
            return await _context.Subdepartments.Include(x => x.Departments).ToListAsync();
        }

        public async Task<List<Subdepartments>> GetWebAllSubdepartmentsAsync()
        {
            return await _context.Subdepartments.Include(x => x.Departments).ToListAsync();
        }

        
    }
}
