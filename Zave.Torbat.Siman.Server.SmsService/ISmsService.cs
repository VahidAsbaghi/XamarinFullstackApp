using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Zave.Torbat.Siman.Server.SmsService
{
    public interface ISmsService
    {
        Task<SmsResponseModel> SendSmsAsync(string mobileNumber, string message);
    }
}
