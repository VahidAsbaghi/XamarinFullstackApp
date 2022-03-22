using System;
using System.Collections.Generic;

namespace Zave.Torbat.Siman.Model.Models1.Factory
{
    public partial class TWContractor
    {
        public int Row { get; set; }
        public string Name { get; set; }
        public bool? Closed { get; set; }
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set; }
        public bool? Deleted { get; set; }
    }
}
