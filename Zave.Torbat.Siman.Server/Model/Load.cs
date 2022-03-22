using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Zave.Torbat.Siman.Server.Model
{
    public class Load
    {
        public string CustomerName { get; set; }
        public double Amount { get; set; }
        public string HandOverAddress { get; set; }
        public string BossName { get; set; }
        public string TransportationType { get; set; }
        public string HandOverTime { get; set; }
        public string Product { get; set; }
        public long LoadId { get; set; }
        public string EnableTime { get; set; }
    }
}
