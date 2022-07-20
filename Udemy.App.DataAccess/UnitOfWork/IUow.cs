using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Udemy.App.DataAccess.Interfaces;
using Udemy.App.Entities;

namespace Udemy.App.DataAccess.UnitOfWork
{
    public interface IUow 
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        Task SaveChangesAsync();
    }
}
