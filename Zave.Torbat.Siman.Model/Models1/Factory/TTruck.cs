using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Zave.Torbat.Siman.Model.Models1.Factory
{
    public partial class TTruck
    {
        public long Row { get; set; }
        public string Card { get; set; }
        public bool? P { get; set; }
        public string Pelak { get; set; }
        public string DriverName { get; set; }
        public string NationalCode { get; set; }
        public string Mobile { get; set; }
        public string Truck { get; set; }
        public bool? Enable { get; set; }
        public DateTime? TechDate { get; set; }
        public DateTime? InsureDate { get; set; }
        public bool? AndroidEnable { get; set; }
        public string Terminal { get; set; }
        public bool? ChangeTerminal { get; set; }
        public bool? Delete { get; set; }
        public DateTime? InsertDate { get; set; }
        public string InsertMan { get; set; }
        public DateTime? EditeDate { get; set; }
        public string EditeMan { get; set; }
        public int? TruckMistake { get; set; }
        public long? RowDriver { get; set; }
        public bool? New { get; set; }
    }
}
