using System;
using System.Collections.Generic;

namespace Zave.Torbat.Siman.Model.Models1.Factory
{
    public partial class TSms
    {
        public int Row { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Domain { get; set; }
        public string Url { get; set; }
        public string Port { get; set; }
        public string Smsuser { get; set; }
        public string Smspass { get; set; }
        public string Smsnum { get; set; }
        public string Paterncode { get; set; }
        public string Terminal { get; set; }
        public string Txt1 { get; set; }
        public string Txt2 { get; set; }
        public string Txt3 { get; set; }
        public string Txt4 { get; set; }
        public string Txt5 { get; set; }
        public string Send { get; set; }
        public bool? FaleDakheli { get; set; }
        public bool? FaleSaderat { get; set; }
        public bool? PakatDakheli { get; set; }
        public bool? PakatSaderat { get; set; }
        public bool? KilinkerDakheli { get; set; }
        public bool? KilinkerSaderat { get; set; }
        public bool? BigDakheli { get; set; }
        public bool? BigSaderat { get; set; }
    }
}
