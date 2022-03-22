using System.Threading.Tasks;
using FarazSmsServiceReference;

namespace Zave.Torbat.Siman.Server.SmsService
{
    public class FarazSendTakeLoadNotification : IFarazSmsService
    {
        public async Task<SmsResponseModel> SendSms(string mobileNumber, params string[] data)
        {
            smsserverPortTypeClient cs = new smsserverPortTypeClient();
            var minutesDeadline = data[0];
            var result = await cs.sendPatternSmsAsync(SecureConstants.SmsNumber1, new[] {mobileNumber},
                SecureConstants.Username, SecureConstants.Password, SecureConstants.LoadPatternCode,
                new input_data_type[] {new input_data_type() {key = "minutes", value = minutesDeadline}});
            if (result.@return != "")
            {
                result = await cs.sendPatternSmsAsync(SecureConstants.SmsNumber2, new[] { mobileNumber },
                    SecureConstants.Username, SecureConstants.Password, SecureConstants.LoadPatternCode,
                    new input_data_type[] { new input_data_type() { key = "minutes", value = minutesDeadline } });
            }
            var returnResult = new SmsResponseModel { Result = result.@return };
            return returnResult;
        }
    }
}