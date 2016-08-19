using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Respositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        T GetById(long id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        IQueryable<T> GetAllWhere(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] include);

        T GetFirstWhere(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] include);

        T GetSingleWhere(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] include);
        T GetSingleOrDefaultWhere(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] include);
    }
}
