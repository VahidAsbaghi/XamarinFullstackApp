using System;
using System.Collections.Generic;

namespace Zave.Torbat.Siman.Model.Models1.Terminal
{
    public partial class TTakhalofat
    {
        public int Row { get; set; }
        public string Name { get; set; }
        public string NumCertificates { get; set; }
        public DateTime? Date { get; set; }
        public string Takhalof { get; set; }
        public string Taahod { get; set; }
        public string Karbar { get; set; }
    }
}
