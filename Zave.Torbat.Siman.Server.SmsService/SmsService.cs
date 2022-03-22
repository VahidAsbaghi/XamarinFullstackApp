using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payamkotah.SmsService;

namespace Zave.Torbat.Siman.Server.SmsService
{
    public class SmsService:ISmsService
    {
        private const string Username = "itzave";
        private const string Password = "ztccit147";
        private const string LineNumber = "30002222000000";

        public async Task<SmsResponseModel> SendSmsAsync(string mobileNumber, string message)
        {
            SMSPanelSoapClient smsPanelSoapClient=new SMSPanelSoapClient(SMSPanelSoapClient.EndpointConfiguration.SMSPanelSoap12);
            var response=await smsPanelSoapClient.FastSendAsync(Username, Password, LineNumber, mobileNumber, message, true, false,
                false);
            return new SmsResponseModel(){ReferenceCode = response.Body.Refrence.ToString(),Result = response.Body.FastSendResult};
        }

    }
}
