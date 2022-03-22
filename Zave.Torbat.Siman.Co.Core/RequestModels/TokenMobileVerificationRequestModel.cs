using System;
using System.Collections.Generic;
using System.Text;

namespace Zave.Torbat.Siman.Co.Core.RequestModels
{
    public class TokenMobileVerificationRequestModel
    {
        public string VerifyToken { get; set; }
        public DateTime ExpirationTime { get; set; }
        public int RequestCount { get; set; }
    }
}
