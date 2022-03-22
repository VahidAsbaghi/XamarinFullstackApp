using System.Threading.Tasks;
using FarazSmsServiceReference;

namespace Zave.Torbat.Siman.Server.SmsService
{
    public class FarazSendTurnNotification : IFarazSmsService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mobileNumber"></param>
        /// <param name="data">
        /// data[0]=plaque
        /// data[1]=date
        /// data[2]=terminal
        /// data[3]=product
        /// data[4]=turnNumber</param>
        /// <returns></returns>
        public async Task<SmsResponseModel> SendSms(string mobileNumber, params string[] data)
        {
            smsserverPortTypeClient cs = new smsserverPortTypeClient();
            var result = await cs.sendPatternSmsAsync(SecureConstants.SmsNumber1, new[] {mobileNumber},
                SecureConstants.Username, SecureConstants.Password, SecureConstants.TurnPatternCode,
                new input_data_type[]
                {
                    new input_data_type() {key = "pelak", value = data[0]},
                    new input_data_type() {key = "date", value = data[1]},
                    new input_data_type() {key = "terminal", value = data[2]},
                    new input_data_type() {key = "product", value = data[3]},
                    new input_data_type() {key = "nobat_number", value = data[4]}
                });
            if (result.@return != "")
            {
                result = await cs.sendPatternSmsAsync(SecureConstants.SmsNumber2, new[] { mobileNumber },
                    SecureConstants.Username, SecureConstants.Password, SecureConstants.TurnPatternCode,
                    new input_data_type[]
                    {
                        new input_data_type() {key = "pelak", value = data[0]},
                        new input_data_type() {key = "date", value = data[1]},
                        new input_data_type() {key = "terminal", value = data[2]},
                        new input_data_type() {key = "product", value = data[3]},
                        new input_data_type() {key = "nobat_number", value = data[4]}
                    });
            }
            var returnResult = new SmsResponseModel { Result = result.@return };
            return returnResult;
        }

    }
}