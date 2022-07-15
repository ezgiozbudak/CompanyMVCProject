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
    public class TopDepartmentRepository : GenericRepository<TopDepartments>, ITopDepartmentRepository
    {
        public TopDepartmentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<TopDepartments>> GetApiAllTopDepartmentsAsync()
        {
            return await _context.TopDepartments.Include(x => x.Departments).ToListAsync();
        }

        public async Task<List<TopDepartments>> GetWebAllTopDepartmentsAsync()
        {
            return await _context.TopDepartments.Include(x => x.Departments).ToListAsync();
        }
    }
}
