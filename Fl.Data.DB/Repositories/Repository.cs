﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using Fl.Data.Core.Repositories;

namespace Fl.Data.DB.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public void AddOrUpdate(TEntity item)
        {
            Context.Set<TEntity>().AddOrUpdate(item);
        }

        public void AddRange(IEnumerable<TEntity> items)
        {
            Context.Set<TEntity>().AddRange(items);
        }

        public void Remove(TEntity item)
        {
            Context.Set<TEntity>().Remove(item);
        }

        public void RemoveRange(IEnumerable<TEntity> items)
        {
            Context.Set<TEntity>().RemoveRange(items);
        }
    }
}
