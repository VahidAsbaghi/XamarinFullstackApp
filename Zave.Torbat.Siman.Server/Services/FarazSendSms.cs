using System.Threading.Tasks;
using Zave.Torbat.Siman.Server.SmsService;

namespace Zave.Torbat.Siman.Server.Services
{
    class FarazSendSms : IFarazSendSms
    {
        public async Task<SmsResponseModel> SendActivationSms(string mobileNumber, string activationCode)
        {
            var farazSmsSender=new FarazSendActivationCode();
            var result=await farazSmsSender.SendSms(mobileNumber, activationCode);
            return result;
        }

        public async Task<SmsResponseModel> SendTurnSms(string mobileNumber, string plaque, string date, string terminal, string product, string turnNumber)
        {
            var farazSmsSender = new FarazSendTurnNotification();
            var result = await farazSmsSender.SendSms(mobileNumber, plaque, date, terminal, product, turnNumber);
            return result;
        }

        public async Task<SmsResponseModel> SendLoadSms(string mobileNumber, string minutesDeadline)
        {
            var farazSmsSender = new FarazSendTakeLoadNotification();
            var result = await farazSmsSender.SendSms(mobileNumber, minutesDeadline);
            return result;
        }
    }
}