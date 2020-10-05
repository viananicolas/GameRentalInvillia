using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameRentalInvillia.Core.Entities.Base;

namespace GameRentalInvillia.Core.Interface
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetAsync(Guid id);
        IEnumerable<TEntity> GetAll();
        TEntity Add(TEntity entity);
        int Update(TEntity entity);
        IEnumerable<TEntity> GetAll(Func<TEntity, bool> fnc);
    }
}