using System;
using System.Collections.Generic;
using System.Text;

namespace Zave.Torbat.Siman.Co.Core.Models
{
    public class TruckViewModel
    {
        public string CardNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string DriverName { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        //public bool TruckTakeLoadAccess { get; set; }
    }
}
