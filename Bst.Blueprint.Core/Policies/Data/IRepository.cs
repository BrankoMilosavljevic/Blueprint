using System;
using System.Linq;
using System.Linq.Expressions;
using Bst.Blueprint.Core.Models;

namespace Bst.Blueprint.Core.Policies.Data
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> Entities();
        IQueryable<T> EntitiesIncluding(params Expression<Func<T, object>>[] paths);
        void Add(T entity);
        void Delete(T entity);
        T GetById(int id);
    }
}
