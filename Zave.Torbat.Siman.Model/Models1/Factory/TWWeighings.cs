using System;
using System.Collections.Generic;

namespace Zave.Torbat.Siman.Model.Models1.Factory
{
    public partial class TWWeighings
    {
        public long Row { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public short? CarCode { get; set; }
        public string Pelak { get; set; }
        public string Contractor { get; set; }
        public string SComp { get; set; }
        public string CarType { get; set; }
        public string Loads { get; set; }
        public string DComp { get; set; }
        public string Baskool { get; set; }
        public int? W1 { get; set; }
        public DateTime? Time1 { get; set; }
        public int? W2 { get; set; }
        public DateTime? Time2 { get; set; }
        public int? W3 { get; set; }
        public DateTime? Date { get; set; }
        public string Block { get; set; }
        public int? WeighingNumber { get; set; }
        public string Karbar { get; set; }
        public bool? Cansel { get; set; }
        public bool? Body { get; set; }
        public bool? Chopper { get; set; }
        public string UserEdit { get; set; }
        public DateTime? DateEdit { get; set; }
        public string DisEdit { get; set; }
        public string Description { get; set; }
    }
}
