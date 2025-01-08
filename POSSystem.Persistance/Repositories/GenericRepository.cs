using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POSSystem.Domain.Interfaces.GenericInterface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace POSSystem.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepo<T> where T : class
    {
        private readonly POSSystemDBContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(POSSystemDBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<bool> CreateAsync(T entity)
        {
            if (entity == null)
            {
                return false;
            }
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                 _dbSet.Remove(entity);
                 _context.SaveChangesAsync();
                return true;
            }
          return false;
        }

        

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<bool> UpdateAsync(T entity)
        {

            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
