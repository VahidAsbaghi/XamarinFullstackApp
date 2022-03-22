using System;
using System.Collections.Generic;

namespace Zave.Torbat.Siman.Model.Models1.Factory
{
    public partial class TWGroup
    {
        public int Row { get; set; }
        public string GroupName { get; set; }
        public bool? Cancel { get; set; }
        public DateTime? Date { get; set; }
        public string UserEdit { get; set; }
    }
}
