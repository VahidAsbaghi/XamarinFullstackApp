using System;

namespace Zave.Torbat.Siman.Server.Model
{
    public class TokenVerificationModel
    {
        public string VerifyToken { get; set; }
        public DateTime ExpirationTime { get; set; }
        public int RequestCount { get; set; }
    }
}
