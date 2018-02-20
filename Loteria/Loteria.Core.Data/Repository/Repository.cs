using System;
using System.Collections.Generic;
using System.Linq;
using Loteria.Core.Data.Repository.Interfaces;
using Loteria.Shared.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace Loteria.Core.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _memoryCacheEntryOptions;
        private readonly string _key;

        public Repository(IMemoryCache memoryCache, MemoryCacheEntryOptions memoryCacheEntryOptions, string key)
        {
            _memoryCache = memoryCache;
            _memoryCacheEntryOptions = memoryCacheEntryOptions;
            _key = key;
        }

        public TEntity Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("A entidade não pode ser nula");

            var items = GetItems();

            items.Add(entity);

            _memoryCache.Set(_key, items);

            return entity;
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("A entidade não pode ser nula");

            var items = GetItems();

            if (items != null)
            {
                var item = items.FirstOrDefault(o => o.Id == entity.Id);

                if (items.Remove(item))
                    _memoryCache.Set(_key, items);
            }
        }

        public virtual IEnumerable<TEntity> GetAll() => _memoryCache.Get<List<TEntity>>(_key) ?? new List<TEntity>();

        public virtual IEnumerable<TEntity> GetByFilter(Func<TEntity, bool> filters) => _memoryCache.Get<List<TEntity>>(_key).Where(filters);

        public virtual TEntity GetById(int id) => _memoryCache.Get<List<TEntity>>(_key).FirstOrDefault(o => o.Id == id);

        public virtual int GetNextId()
        {
            return this.GetAll().Any() ? this.GetAll().Max(o => o.Id) + 1 : 1;
        }

        private List<TEntity> GetItems() => _memoryCache.Get<List<TEntity>>(_key) ?? new List<TEntity>();
    }
}
