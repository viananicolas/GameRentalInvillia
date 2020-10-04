using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameRentalInvillia.Core.Entities.Base;

namespace GameRentalInvillia.Core.Interface
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetAsync(Guid id);
        Task<TEntity> GetAsync(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        int Update(TEntity entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAllAsync();
        IEnumerable<TEntity> GetAll(Func<TEntity, bool> fnc);
    }
}