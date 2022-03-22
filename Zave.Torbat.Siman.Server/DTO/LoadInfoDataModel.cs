using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zave.Torbat.Siman.Server.Model;

namespace Zave.Torbat.Siman.Server.DTO
{
    public class LoadInfoDataModel
    {
        public string BossName { get; set; }
        public string CustomerName { get; set; }
        public string Product { get; set; }
        public string Weight { get; set; }
        public string DestinationAddress { get; set; }
        public string LoadingType { get; set; }
        public string HandoverTime { get; set; }
    }
}
