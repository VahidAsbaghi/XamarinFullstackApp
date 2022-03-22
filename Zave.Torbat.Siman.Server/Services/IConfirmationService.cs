using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zave.Torbat.Siman.Server.SmsService;

namespace Zave.Torbat.Siman.Server.Services
{
    public interface IConfirmationService
    {
        Task<SmsResponseModel> ConfirmPhoneNumberBySmsAsync(string mobileNumber, string token);
    }
}
