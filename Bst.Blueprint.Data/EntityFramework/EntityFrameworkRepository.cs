using System;
using System.Linq;
using System.Linq.Expressions;
using Bst.Blueprint.Core.Models;
using Bst.Blueprint.Core.Policies.Data;
using Microsoft.EntityFrameworkCore;

namespace Bst.Blueprint.Data.EntityFramework
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : Entity
    {
        private DbSet<T> DbSet { get; }

        private DbContext DbContext { get; }

        public EntityFrameworkRepository(DbContext context)
        {
            DbContext = context;
            DbSet = context.Set<T>();
        }

        public IQueryable<T> Entities()
        {
            return DbSet;
        }

        public IQueryable<T> EntitiesIncluding(params Expression<Func<T, object>>[] paths)
        {
            if (paths == null)
                throw new ArgumentNullException(nameof(paths));

            return paths.Aggregate<Expression<Func<T, object>>, IQueryable<T>>(DbSet,
                (current, includeProperty) => current.Include(includeProperty));
        }

        public void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Id != 0)
                throw new InvalidOperationException("You cannot add entity that has Id set.");

            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            DbSet.Remove(entity);
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }
    }
}
