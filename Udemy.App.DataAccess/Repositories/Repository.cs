using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Udemy.App.Common.Enums;
using Udemy.App.DataAccess.Contexts;
using Udemy.App.DataAccess.Interfaces;
using Udemy.App.Entities;

namespace Udemy.App.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T:BaseEntity
    {
         private readonly  UygulamaContext _context;

     
        public Repository(UygulamaContext context)
        {
            _context = context;
        }

        // Hepsini Getir
        public async Task<List<T>> GetAllAsyncDal() 
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        //Filtreleyerek Hepsini Getir
        public async Task<List<T>> GetAllAsyncDal(Expression<Func<T,bool>> filter)  
        {
            return await _context.Set<T>().Where(filter).AsNoTracking().ToListAsync();
        }

        //Sıralı Hepsini Getir
        public async Task<List<T>> GetAllAsyncDal<TKey>(Expression<Func<T, TKey>> selector, OrderbyType orderbyType) 
        {
            return orderbyType == OrderbyType.ASC ? await _context.Set<T>().AsNoTracking().OrderBy(selector).ToListAsync() :
                                                    await _context.Set<T>().AsNoTracking().OrderByDescending(selector).ToListAsync();
        }

        //Sıralı ve Filtreli Hepsini Getir
        public async Task<List<T>> GetAllAsyncDal<TKey>(Expression<Func<T, bool>> filter , Expression<Func<T, TKey>> selector, OrderbyType orderbyType) 
        {
            return orderbyType == OrderbyType.ASC ? await _context.Set<T>().Where(filter).AsNoTracking().OrderBy(selector).ToListAsync() :
                                                    await _context.Set<T>().Where(filter).AsNoTracking().OrderByDescending(selector).ToListAsync();
        }

        //Bul
        public async Task<T> FindAsyncDal(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByFilterAsyncDal(Expression<Func<T,bool>> filter, bool asNoTracking = false)
        {
            return !asNoTracking ? await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter) 
                                 : await _context.Set<T>().SingleOrDefaultAsync(filter);
        }

        public IQueryable<T> GetQueryDal()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void RemoveDal(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task CreateAsyncDal(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
        } 

        public void UpdateDal(T entity, T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }


    }
}
