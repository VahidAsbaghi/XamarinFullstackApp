using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zave.Torbat.Siman.Server.SmsService;

namespace Zave.Torbat.Siman.Server.Services
{
    public class ConfirmationService : IConfirmationService
    {
        private readonly IFarazSendSms _farazSms;
        //private readonly IServerSmsService _smsService;

        public ConfirmationService(IFarazSendSms farazSms)//IServerSmsService smsService)
        {
            _farazSms = farazSms;
            //_smsService = smsService;
        }
        public Task<SmsResponseModel> ConfirmPhoneNumberBySmsAsync(string mobileNumber, string token)
        {
            //var message = GenerateMobileConfirmationMessage(token);
            return _farazSms.SendActivationSms(mobileNumber,token);

        }

        //private string GenerateMobileConfirmationMessage(string code)
        //{
        //    //var code = GenerateConfirmationCode();
        //    var message = $"کد تایید ورود شما در شرکت سیمان زاوه {code} میباشد";
        //    return message;
        //}
        
    }
}