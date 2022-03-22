using System;

namespace Zave.Torbat.Siman.Co.Core.ResponseModels
{
    public class StartPhoneVerificationResult:ResponseModelBase
    {
        public int TimeOutSeconds { get; set; }
        public DateTime IssueDateTime { get; set; }
        public DateTime ExpirationTime => IssueDateTime.AddSeconds(TimeOutSeconds);
    }
}
