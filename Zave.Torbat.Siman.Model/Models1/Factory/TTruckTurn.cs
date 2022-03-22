using System;
using System.Collections.Generic;

namespace Zave.Torbat.Siman.Model.Models1.Factory
{
    public partial class TTruckTurn
    {
        public long Row { get; set; }
        public bool? P { get; set; }
        public string Pelak { get; set; }
        public string Product { get; set; }
        public long? RowTruck { get; set; }
        public string Terminal { get; set; }
        public bool? Enable { get; set; }
        public bool? Android { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDateNobat { get; set; }
        public bool? Call1 { get; set; }
        public DateTime? DateCall1 { get; set; }
        public string DeletedCall1 { get; set; }
        public bool? Call2 { get; set; }
        public DateTime? DateCall2 { get; set; }
        public string DeletedCall2 { get; set; }
        public bool? Call3 { get; set; }
        public DateTime? DateCall3 { get; set; }
        public string DeletedCall3 { get; set; }
        public string EditeMan { get; set; }
        public DateTime? DateEdit { get; set; }
        public bool? Deleted { get; set; }
        public int? Turn { get; set; }
        public DateTime? TurnDate { get; set; }
    }
}
