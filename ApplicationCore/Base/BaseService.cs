using Domain.Base;
using Domain.Interfaces;
using Infrastructure.Base;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Base
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IGenericRepository<T> repository;
        private readonly IUnitOfWork unitOfWork;
        public BaseService(IUnitOfWork unitOfWork)
        {
            this.repository = unitOfWork.Repository<T>();
            this.unitOfWork = unitOfWork;
        }

        public async Task<T> AddAsync(T entity)
        {
            var repository = unitOfWork.Repository<T>(); 
            return await repository.AddAsync(entity); 
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            repository.Update(entity);
        }

        public void Delete(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            repository.Delete(where);
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return repository.Get(where);
        }

        public T GetById(params object[] keyValues)
        {
            return repository.GetById(keyValues);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> filter = null)
        {
            return repository.GetMany(filter);
        }

        public virtual void Update(T entity)
        {
            repository.Update(entity);
        }
    }
}
