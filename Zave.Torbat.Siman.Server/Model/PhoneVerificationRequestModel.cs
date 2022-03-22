using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zave.Torbat.Siman.Server.Model
{
    public class PhoneVerificationRequestModel
    {
        public string ImeiCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
