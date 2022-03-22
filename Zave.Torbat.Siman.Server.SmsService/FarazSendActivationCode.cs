using System.Net;
using System.Threading.Tasks;
using FarazSmsServiceReference;
using Payamkotah.SmsService;

namespace Zave.Torbat.Siman.Server.SmsService
{
    public class FarazSendActivationCode : IFarazSmsService
    {
        public async Task<SmsResponseModel> SendSms(string mobileNumber, params string[] data)
        {
            smsserverPortTypeClient cs = new smsserverPortTypeClient();
            SMSPanelSoapClient smsPanel=new SMSPanelSoapClient(SMSPanelSoapClient.EndpointConfiguration.SMSPanelSoap);
            

            var activationCode = data[0];
            NetworkCredential networkCredential=new NetworkCredential("bagherian","123321","ztcf");
            WebProxy webProxy=new WebProxy("192.168.100.100:8080",true){Credentials = networkCredential};
            
            var result = await cs.sendPatternSmsAsync(SecureConstants.SmsNumber1, new[] {mobileNumber},
                SecureConstants.Username, SecureConstants.Password, SecureConstants.ActivationPatternCode,
            new input_data_type[] {new input_data_type() {key = "code", value = activationCode}});
            if (result.@return!="")
            {
                result = await cs.sendPatternSmsAsync(SecureConstants.SmsNumber2, new[] { mobileNumber },
                    SecureConstants.Username, SecureConstants.Password, SecureConstants.ActivationPatternCode,
                    new input_data_type[] { new input_data_type() { key = "code", value = activationCode } });
            }
            var returnResult = new SmsResponseModel { Result = result.@return };
            return returnResult;
        }
    }
}