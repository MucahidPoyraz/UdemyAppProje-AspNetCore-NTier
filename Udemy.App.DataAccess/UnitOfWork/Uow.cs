using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Udemy.App.DataAccess.Contexts;
using Udemy.App.DataAccess.Interfaces;
using Udemy.App.DataAccess.Repositories;
using Udemy.App.Entities;

namespace Udemy.App.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly UygulamaContext _context;

        public Uow(UygulamaContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
