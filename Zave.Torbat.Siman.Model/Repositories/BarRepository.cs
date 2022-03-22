using System;
using System.Collections.Generic;
using System.Text;
using Zave.Torbat.Siman.Model.DbContexts;
using Zave.Torbat.Siman.Model.Models1.Terminal;

namespace Zave.Torbat.Siman.Model.Repositories
{
    public class BarRepository:GenericRepository<TBarNew>
    {
        public BarRepository(DB_TerminalContext dataContext) : base(dataContext)
        {
        }
    }
}
