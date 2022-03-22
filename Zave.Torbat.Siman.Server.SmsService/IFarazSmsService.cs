using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Zave.Torbat.Siman.Server.SmsService
{
    public interface IFarazSmsService
    {
        Task<SmsResponseModel> SendSms(string mobileNumber, params string[] data);
    }
}