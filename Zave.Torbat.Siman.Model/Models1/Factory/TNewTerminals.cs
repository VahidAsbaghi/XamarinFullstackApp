using System;
using System.Collections.Generic;

namespace Zave.Torbat.Siman.Model.Models1.Factory
{
    public partial class TNewTerminals
    {
        public long Row { get; set; }
        public int? Code { get; set; }
        public string Name { get; set; }//name terminalhaie molkhtalef ke ba sherkat kar mikonand
        public bool? Enable { get; set; }
        public bool? AndroidEnable { get; set; }
        public int? NoeFale { get; set; }
        public int? NoePakati { get; set; }
        public int? NoeClinker { get; set; }
        public int? NoeBigbag { get; set; }
        public DateTime? StartTime { get; set; } //time bargiri
        public double? Fale { get; set; }
        public double? Pakati { get; set; }
        public double? Clinker { get; set; }
        public double? Bigbag { get; set; }
        public int? Mistake { get; set; }
        public int? Score { get; set; }
        public bool? Delete { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string EditeMan { get; set; }
        public string EditeDate { get; set; }
        public int? DeleteNobat { get; set; }
    }
}
