using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    
    public class DataService<T>:IDataService<T> where T :class,IBaseEntity
    {
        private ApplicationDbContext _context;

        public DataService(ApplicationDbContext context) => _context = context;
    
            public async Task<T> Get(Guid id)
            {
               return  await _context.FindAsync<T>(id);
            }

        public async Task Delete(Guid id)
        {
            var entity = await _context.FindAsync<T>(id);

            _context.Remove<T>(entity);

            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<T>> GetAll()
            {
               return await _context.Set<T>().ToListAsync();
            }

        public async Task<Guid> Insert(T entity)
            {
                
               await _context.AddAsync(entity);
               await _context.SaveChangesAsync();

               return entity.Id;
            }

            public async Task<Guid> Update(T entity)
            {
                _context.Update(entity);
               await _context.SaveChangesAsync();

               return entity.Id;

             }
        public IQueryable<T> Query(Expression<Func<T, bool>> predicate)
        {
            var query = _context.Set<T>().AsQueryable();

            if (predicate != null)
                query = query.Where(predicate);

            return query;
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>();
        }
    }
}