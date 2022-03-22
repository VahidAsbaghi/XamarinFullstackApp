using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarazSmsServiceReference;
using Zave.Torbat.Siman.Server.SmsService;

namespace Zave.Torbat.Siman.Server.Services
{
    public interface IFarazSendSms
    {
        Task<SmsResponseModel> SendActivationSms(string mobileNumber, string activationCode);
        Task<SmsResponseModel> SendTurnSms(string mobileNumber, string plaque,string date, string terminal, string product, string turnNumber);
        Task<SmsResponseModel> SendLoadSms(string mobileNumber, string minutesDeadline);
    }
}
