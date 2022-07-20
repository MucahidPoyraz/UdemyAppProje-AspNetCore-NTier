using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Udemy.App.Common.Enums;
using Udemy.App.Entities;

namespace Udemy.App.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsyncDal();
        Task<List<T>> GetAllAsyncDal(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllAsyncDal<TKey>(Expression<Func<T, TKey>> selector, OrderbyType orderbyType);
        Task<List<T>> GetAllAsyncDal<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector, OrderbyType orderbyType);
        Task<T> FindAsyncDal(object id);
        Task<T> GetByFilterAsyncDal(Expression<Func<T, bool>> filter, bool asNoTracking = false);
        IQueryable<T> GetQueryDal();
        void RemoveDal(T entity);
        Task CreateAsyncDal(T entity);
        void UpdateDal(T entity, T unchanged);

    }
}
