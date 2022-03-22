using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zave.Torbat.Siman.Server.Model;

namespace Zave.Torbat.Siman.Server.Services
{
    public interface IMainPageDataService
    {
        string GetCurrentPosition(Truck truck);
    }
}
