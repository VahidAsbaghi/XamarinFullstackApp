using System;
using System.Collections.Generic;

namespace Zave.Torbat.Siman.Model.Models1.Terminal
{
    public partial class TCustomers
    {
        public int Row { get; set; }
        public string Name { get; set; }
        public string Mobail { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Bosscode { get; set; }
        public bool? Delette { get; set; }
        public string CityName { get; set; }
        public int? CityCode { get; set; }
        public string Bakhsh { get; set; }
        public int? CrmCode { get; set; }
    }
}
