using GameRentalInvillia.Core.Entities.Base;
using GameRentalInvillia.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRentalInvillia.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GameRentalInvillia.Infra.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext ApplicationDbContext;

        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await ApplicationDbContext.Set<TEntity>().AddAsync(entity);
            await ApplicationDbContext.SaveChangesAsync();

            return entity;
        }        
        public TEntity Add(TEntity entity)
        {
            ApplicationDbContext.Set<TEntity>().Add(entity);
            ApplicationDbContext.SaveChanges();

            return entity;
        }

        public async Task<int> DeleteAllAsync()
        {
            var existed = ApplicationDbContext.Set<TEntity>();
            ApplicationDbContext.Set<TEntity>().RemoveRange(existed);
            return await ApplicationDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var existed = await GetAsync(id);
            ApplicationDbContext.Set<TEntity>().Remove(existed);
            return await ApplicationDbContext.SaveChangesAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return ApplicationDbContext.Set<TEntity>().Where(e => !e.Deleted);
        }

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool> fnc)
        {
            return ApplicationDbContext.Set<TEntity>().Where(fnc).AsEnumerable();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await ApplicationDbContext.Set<TEntity>().Where(e => !e.Deleted).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TEntity> GetAsync(TEntity entity)
        {
            return await GetAsync(entity.Id);
        }

        public async Task<int> UpdateAsync(TEntity entities)
        {
            ApplicationDbContext.Set<TEntity>().UpdateRange(entities);
            return await ApplicationDbContext.SaveChangesAsync();
        }        
        public int Update(TEntity entities)
        {
            ApplicationDbContext.Set<TEntity>().UpdateRange(entities);
            return ApplicationDbContext.SaveChanges();
        }
    }
}