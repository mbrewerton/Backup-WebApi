using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Respositories
{
    public interface IUnitOfWork
    {
        void Dispose();
        void Commit();
    }
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IObjectContext _context;
        
        public UnitOfWork(IObjectContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
