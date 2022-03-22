using System;
using System.Collections.Generic;

namespace Zave.Torbat.Siman.Model.Models1.Factory
{
    public partial class TTempStart
    {
        public int Row { get; set; }
        public string Terminal { get; set; }
        public int? NumOfStartFalleh { get; set; }
        public int? NumOfStartPakati { get; set; }
        public int? NumOfStartClinker { get; set; }
        public int? NumOfStartBigbag { get; set; }
        public DateTime? Date { get; set; }
    }
}
