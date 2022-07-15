using Company.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.UnitOfWorks
{
    public class UnitOfWork : IGenericUnitOfWork
    {
        private readonly AppDbContexts.AppDbContext _context;
        public UnitOfWork(AppDbContexts.AppDbContext context)
        {
            _context = context;
        }


        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }



    }
}
