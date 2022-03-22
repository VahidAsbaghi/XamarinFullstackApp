using System.Collections.Generic;
using System.Threading.Tasks;
using Zave.Torbat.Siman.Co.Core.Models;
using Zave.Torbat.Siman.Co.Core.RequestModels;
using Zave.Torbat.Siman.Co.Core.ResponseModels;

namespace Zave.Torbat.Siman.Co.Core.Services
{
    public interface IAuthenticationService
    {
        string Login(Credentials credentials);
        string GetUser(string token);
        Task<TokenMobileVerificationResponseModel> ConfirmPhone(TokenMobileVerificationRequestModel verifyToken, string token);
        Task<StartPhoneVerificationResult> StartPhoneConfirmation(string phoneNumber, string originalToken);
        Task<bool> LogOut(string originalToken);
        Task<List<string>> GetUserPlaques(string token);
    }
}
