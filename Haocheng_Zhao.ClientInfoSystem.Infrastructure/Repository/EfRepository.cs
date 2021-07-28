using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haocheng_Zhao.ClientInfoSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Haocheng_Zhao.ClientInfoSystem.Infrastructure.Repository
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly ClientInfoSystemDbContext _dbContext;
        public EfRepository(ClientInfoSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async virtual Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public Task<bool> GetExistsAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
