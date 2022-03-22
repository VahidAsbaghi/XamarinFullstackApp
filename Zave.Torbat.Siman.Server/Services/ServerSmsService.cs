using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zave.Torbat.Siman.Server.SmsService;

namespace Zave.Torbat.Siman.Server.Services
{
    public class ServerSmsService : IServerSmsService
    {
        private readonly ISmsService _smsService;

        public ServerSmsService(ISmsService smsService)
        {
            _smsService = smsService;
        }
        public Task<SmsResponseModel> SendSms(string mobileNumber, string message)
        {
            return _smsService.SendSmsAsync(mobileNumber, message);
        }
    }
}