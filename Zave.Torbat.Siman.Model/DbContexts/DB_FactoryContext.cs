using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zave.Torbat.Siman.Model.DbContexts;

namespace Zave.Torbat.Siman.Model.Models1.Factory
{
    public partial class DB_FactoryContext: IDataContext
    {
        public DbSet<T> GetDbSet<T>() where T : class
        {
            return Set<T>();
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

    }
}
