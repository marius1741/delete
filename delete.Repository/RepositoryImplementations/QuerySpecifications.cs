using delete.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace delete.Repository.RepositoryImplementations
{
    internal class QuerySpecifications<TEntity> : IQuerySpecifications<TEntity> where TEntity : class
    {
        private IQueryable<TEntity> query;

        public IEnumerable<TEntity> Done()
        {
            return query.ToList();
        }

        public IQuerySpecifications<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate), "You've implemented the query specifications a bit funky");
            }

            query = query.Include(predicate);
            return this;
        }
        public IQuerySpecifications<TEntity> OrderBy<TSortKey>(Expression<Func<TEntity, TSortKey>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate), "You've implemented the query specifications a bit funky");
            }

            query = query.OrderBy(predicate);
            return this;
        }
        public IQuerySpecifications<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate), "You've implemented the query specifications a bit funky");
            }

            query = query.Where(predicate);
            return this;
        }
    }
}
