using System;
using System.Collections.Generic;

namespace Zave.Torbat.Siman.Model.Models1.Factory
{
    public partial class TChopper
    {
        public long Row { get; set; }
        public string TruckCode { get; set; }
        public byte? AntNum { get; set; }
        public byte? Destination { get; set; }
        public int? W { get; set; }
        public string Loads { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Time { get; set; }
        public bool? Delete { get; set; }
        public bool? Body { get; set; }
    }
}
