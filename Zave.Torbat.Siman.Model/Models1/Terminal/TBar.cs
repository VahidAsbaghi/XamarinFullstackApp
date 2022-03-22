using System;
using System.Collections.Generic;

namespace Zave.Torbat.Siman.Model.Models1.Terminal
{
    public partial class TBar
    {
        public long Row { get; set; }
        public string NameBoss { get; set; }
        public string Name { get; set; }
        public string Product { get; set; }
        public double? Ton { get; set; }
        public string Destination { get; set; }
        public string Haml { get; set; }
        public string TimeTakhlie { get; set; }
        public string Mobail { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? Date { get; set; }
        public bool? SelectTruck { get; set; }
        public bool? Waybill { get; set; }
        public string RowSale { get; set; }
        public DateTime? DateHavale { get; set; }
        public int? CountryCode { get; set; }
        public int? ProvinceCode { get; set; }
        public int? CityCode { get; set; }
        public string Status { get; set; }
        public bool? Saderat { get; set; }
        public string Description { get; set; }
        public bool? Deletedd { get; set; }
        public string UserEdit { get; set; }
        public DateTime? DateEdit { get; set; }
        public long? RowCustomers { get; set; }
        public string UserSabt { get; set; }
        public DateTime? DateSabt { get; set; }
        public string Bakhsh { get; set; }
        public string Takhlieh { get; set; }
        public int? CrmCodeB { get; set; }
        public int? CrmCodeC { get; set; }
        public bool? Non { get; set; }
    }
}
