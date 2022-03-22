using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zave.Torbat.Siman.Server.Model
{
    public class PhoneVerificationResponseModel:ResponseModelBase
    {
        public int TimeOutSeconds { get; set; }
        public DateTime IssueDateTime { get; set; }
        public DateTime ExpirationTime => IssueDateTime.AddSeconds(TimeOutSeconds);
    }
}
