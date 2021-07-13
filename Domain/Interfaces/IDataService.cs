using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Guid id);

        Task<Guid> Insert(T entity);
        Task<Guid> Update(T entity);
        Task Delete(Guid Id);
        IQueryable<T> Query(Expression<Func<T, bool>> predicate);
        IQueryable<T> Query();

    }
}
