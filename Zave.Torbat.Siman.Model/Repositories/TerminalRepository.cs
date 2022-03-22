using System;
using System.Collections.Generic;
using System.Text;
using Zave.Torbat.Siman.Model.DbContexts;
using Zave.Torbat.Siman.Model.Models1.Factory;

namespace Zave.Torbat.Siman.Model.Repositories
{
    public class TerminalRepository:GenericRepository<TNewTerminals>
    {
        public TerminalRepository(DB_FactoryContext dataContext) : base(dataContext)
        {
        }
    }
}
