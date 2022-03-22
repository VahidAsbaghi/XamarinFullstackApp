using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zave.Torbat.Siman.Server.Model
{
    public class ResponseDescriptions
    {
        public const string InvalidModelState = "invalid model";
        public const string UserNotFound = "unable to find logged in user";
        public const string TokenGenerated = "token successfully generated";
        public const string SmsSendFailed = "sms sending failed";
        public const string InvalidVerificationToken = "invalid verification token";
        public const string VerificationTokenExpired = "verification token expired";
        public const string MaxRequestExceed = "max request count exceed";
        public const string VerifiedSuccessfully = "successfully verified";
        public const string TruckNotFound = "truck for the user is not found";
    }
}
