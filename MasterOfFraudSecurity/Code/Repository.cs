using System;
using System.Linq;
using System.Threading.Tasks;
using MasterOfFraudSecurity.Entities;

namespace MasterOfFraudSecurity.Code
{
    public class Repository<T> : IDisposable where T : class
    {
        private readonly ApplicationDbContext _context;

        public Repository()
        {
            _context = new ApplicationDbContext();
        }

        public async Task<T> FindAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            var entities = _context.Set<T>();
            return entities;
        }

        public async Task AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}