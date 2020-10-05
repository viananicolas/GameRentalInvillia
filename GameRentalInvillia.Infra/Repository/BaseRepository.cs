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
 
        public TEntity Add(TEntity entity)
        {
            ApplicationDbContext.Set<TEntity>().Add(entity);
            ApplicationDbContext.SaveChanges();

            return entity;
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
      
        public int Update(TEntity entities)
        {
            ApplicationDbContext.Set<TEntity>().UpdateRange(entities);
            return ApplicationDbContext.SaveChanges();
        }
    }
}