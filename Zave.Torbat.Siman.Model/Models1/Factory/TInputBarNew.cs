using System;
using System.Collections.Generic;

namespace Zave.Torbat.Siman.Model.Models1.Factory
{
    public partial class TInputBarNew
    {
        public long Row { get; set; }
        public string CarType { get; set; }//trucktype
        public string Pelak { get; set; }
        public string Driver { get; set; }
        public string NumCertificates { get; set; } //shomare gavahinameh
        public int? Capacity { get; set; } //0
        public string Mobail { get; set; } //shomareh ranandeh
        public string Product { get; set; }
        public string Havale { get; set; } //* 
        public string NameBoss { get; set; } //TBarNew
        public string Name { get; set; } //TBarNew
        public double? Ton { get; set; } //TBarNew Ton
        public string Destination { get; set; } 
        public string Haml { get; set; } //TBarNew NoeHaml
        public string TimeTakhlie { get; set; }
        public string Tozihat { get; set; } //Description
        public DateTime? Date { get; set; } //DateTime.Now
        public string Time { get; set; } //DateTime.Now
        public string Terminal { get; set; } 
        public bool? Cansel { get; set; } //false
        public bool? In { get; set; } //false
        public long? RowSale { get; set; } //TBarNew 
        public DateTime? DateHavale { get; set; } //TBarNew
        public string CarCode { get; set; } //shomareh karte barbari
        public string Barbari { get; set; } //TBarNew
        public bool? Out { get; set; } //false
        public int? CountryCode { get; set; } //TBarNew
        public int? ProvinceCode { get; set; }//TBarNew
        public int? CityCode { get; set; } //TBarNew
        public string Status { get; set; }//TBarNew
        public double? Zarfiat { get; set; } //TTruckType Ton
        public int? Nobat { get; set; } //Turn
        public string CustomMobail { get; set; } ////TTruckType Mobile
        public bool? Loading { get; set; } //false
        public bool? Saderat { get; set; } //TBarNew
        public bool? PS { get; set; } //False
        public string UserEdit { get; set; } //null
        public DateTime? DateEdit { get; set; } //null
        public string DisEdit { get; set; } //null
        public string Description { get; set; } ////Description
        public string Bakhsh { get; set; } //TBarNew
        public string Takhlieh { get; set; }//TBarNew
        public int? CrmCodeB { get; set; }//TBarNew
        public int? CrmCodeC { get; set; }//TBarNew
    }
}
