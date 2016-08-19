using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Respositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected IObjectContext _objectContext;
        protected IDbSet<T> _objectSet;

        public GenericRepository(IObjectContext objectContext)
        {
            _objectContext = objectContext;
            _objectSet = _objectContext.CreateObjectSet<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _objectSet;
        }

        public T GetById(int id)
        {
            return _objectSet.Find(id);
        }

        public T GetById(long id)
        {
            return _objectSet.Find(id);
        }

        public void Add(T entity)
        {
            _objectSet.Add(entity);
        }

        public void Update(T entity)
        {
            _objectContext.GetContext().Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _objectSet.Remove(entity);
        }

        public IQueryable<T> GetAllWhere(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> results = _objectSet.Where(@where);

            if (results.Any())
                results = include.Aggregate(results, (current, expressions) => current.Include(expressions));

            return results;
        }


        public T GetFirstWhere(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] include)
        {
            return GetAllWhere(@where, include).First();
        }

        public T GetSingleWhere(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] include)
        {
            return GetAllWhere(@where, include).Single();
        }

        public T GetSingleOrDefaultWhere(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] include)
        {
            return GetAllWhere(@where, include).SingleOrDefault();
        }
    }
}
