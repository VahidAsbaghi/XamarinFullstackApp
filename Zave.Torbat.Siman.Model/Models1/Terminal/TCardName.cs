using System;
using System.Collections.Generic;

namespace Zave.Torbat.Siman.Model.Models1.Terminal
{
    public partial class TCardName
    {
        public long Row { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Pelak { get; set; }
        public int? Card { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Date { get; set; }
        public string Karbar { get; set; }
    }
}
