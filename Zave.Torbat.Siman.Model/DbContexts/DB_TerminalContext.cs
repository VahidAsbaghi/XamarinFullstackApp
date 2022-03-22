using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zave.Torbat.Siman.Model.DbContexts;

namespace Zave.Torbat.Siman.Model.Models1.Terminal
{
    public partial class DB_TerminalContext:IDataContext
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
