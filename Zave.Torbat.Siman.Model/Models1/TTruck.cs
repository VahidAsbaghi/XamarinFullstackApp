using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Zave.Torbat.Siman.Model.Models1.Factory
{
    public partial class TTruck
    {
        public string PhoneVerificationToken { get; set; }
        public string Token { get; set; }
        public bool IsLoggedIn { get; set; }
        public string PasswordHash { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
    }
}
