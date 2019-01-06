using Bst.Blueprint.Core.Policies.Data;
using Microsoft.EntityFrameworkCore;

namespace Bst.Blueprint.Data.EntityFramework
{
    public class DbContextUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private bool _cancelSaving;

        public DbContextUnitOfWork(DbContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            if (_cancelSaving)
                return;

            _context.SaveChanges();
        }

        public void CancelSaving()
        {
            _cancelSaving = true;
        }
    }
}
