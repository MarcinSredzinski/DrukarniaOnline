using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApplicationLibrary.Repository
{
    public interface IReposotoryBase<T> where T : class
    {
        Task<IEnumerable<T>> FindAllAsync();
        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
        Task<T> GetDetailsAsync(int id);
        Task<T> GetDetailsAsync(int? id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}
