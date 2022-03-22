using Zave.Torbat.Siman.Model.DbContexts;
using Zave.Torbat.Siman.Model.Models1.Factory;
using Zave.Torbat.Siman.Model.Models1.Terminal;

//using Zave.Torbat.Siman.Model.Models.Factory;

namespace Zave.Torbat.Siman.Model.Repositories
{
    public class DriversRepository:GenericRepository<TNewDrivers>//<TNewDrivers>
    {
        public DriversRepository(DB_FactoryContext dataContext) : base(dataContext)
        {
        }
    }
}
