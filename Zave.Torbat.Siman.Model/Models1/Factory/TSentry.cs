using System;
using System.Collections.Generic;

namespace Zave.Torbat.Siman.Model.Models1.Factory
{
    public partial class TSentry
    {
        public long Row { get; set; }
        public string CarType { get; set; }
        public string Pelak { get; set; }
        public string Driver { get; set; }
        public string Mobail { get; set; }
        public string Product { get; set; }
        public string Destination { get; set; }
        public string Tozihat { get; set; }
        public DateTime? DateIn { get; set; }
        public DateTime? DateOut { get; set; }
        public string Polomp { get; set; }
        public bool? Saderat { get; set; }
        public string Karbar { get; set; }
        public bool? In { get; set; }
        public bool? Out { get; set; }
        public string RowIn { get; set; }
        public string UserEdit { get; set; }
        public DateTime? DateEdit { get; set; }
    }
}
