using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Base
{
    public interface IBaseService<T> where T : class
    {
        public Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(params object[] keyValues);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where = null);
        T Get(Expression<Func<T, bool>> where);
        void Commit();
    }
}
