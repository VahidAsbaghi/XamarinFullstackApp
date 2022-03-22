using System;
using System.Collections.Generic;

namespace Zave.Torbat.Siman.Model.Models1.Factory
{
    public partial class TNewDrivers
    {
        public long Row { get; set; }
        public string DriverName { get; set; }
        public string NationalCode { get; set; }
        public string Mobile { get; set; }
        public string CertificateNum { get; set; }
        public DateTime? CertificateDate { get; set; }
        public DateTime? SalamatDate { get; set; }
        public DateTime? HooshmandDate { get; set; }
        public int? Mistake { get; set; }
        public bool? Enable { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string EditeMan { get; set; }
        public DateTime? EditeDate { get; set; }
        public bool? New { get; set; }
    }
}
