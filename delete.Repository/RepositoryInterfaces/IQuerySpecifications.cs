using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace delete.Repository.RepositoryInterfaces
{
    public interface IQuerySpecifications<TEntity> where TEntity : class
    {
        IQuerySpecifications<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        IQuerySpecifications<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> predicate);
        IQuerySpecifications<TEntity> OrderBy<TSortKey>(Expression<Func<TEntity, TSortKey>> predicate);
        IEnumerable<TEntity> Done();
    }
}
