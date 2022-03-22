using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Zave.Torbat.Siman.Server.Model
{
    public class User:IdentityUser
    {
        public string MobileImei { get; set; }
        public string PhoneVerificationToken { get; set; }
        public int NegativePoints { get; set; }
        public string HealthCardDate { get; set; }
        public string SmartCardDate { get; set; }
        public string DrivingLicenseDate { get; set; }
        public string LoadingCardNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        
        public virtual Truck Truck { get; set; }

    }
}
