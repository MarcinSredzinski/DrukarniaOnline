using ApplicationLibrary.Repository;
using Microsoft.EntityFrameworkCore;
using PersistenceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Persistance.RepositoryLibrary
{
    public class RepositoryBase<T> : IReposotoryBase<T> where T : class
    {
        protected DrukarniaDbContext _dbContext { get; set; }

        public RepositoryBase(DrukarniaDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await this._dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await this._dbContext.Set<T>().Where(expression).ToListAsync();
        }

        public void Create(T entity)
        {
            this._dbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this._dbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this._dbContext.Set<T>().Remove(entity);
        }

        public async Task SaveAsync()
        {
            await this._dbContext.SaveChangesAsync();
        }

       
    }
}
