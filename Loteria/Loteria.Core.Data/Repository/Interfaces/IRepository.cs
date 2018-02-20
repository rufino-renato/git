using System;
using System.Collections.Generic;

namespace Loteria.Core.Data.Repository.Interfaces
{
    public interface IRepository<TEntity>
    {
        TEntity Add(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        IEnumerable<TEntity> GetByFilter(Func<TEntity, bool> filters);
        int GetNextId();
    }
}
