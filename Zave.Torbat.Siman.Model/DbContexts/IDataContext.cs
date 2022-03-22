using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Zave.Torbat.Siman.Model.DbContexts
{
    public interface IDataContext : IDisposable
    {
        DbSet<T> GetDbSet<T>() where T : class;
        //DbEntityEntry<T> GetEntry<T>(T entity) where T : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        //void Rollback();

    }
}
