using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zave.Torbat.Siman.Server.Services
{
    public interface ITakeLoadTimeoutService
    {
        void Start(int timeOut);
        void Stop();
        int RemainedTime();
        bool IsTimeOut();
    }
}
