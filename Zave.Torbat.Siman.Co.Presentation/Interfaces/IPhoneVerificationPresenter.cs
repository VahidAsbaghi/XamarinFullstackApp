using System.Threading.Tasks;
using Zave.Torbat.Siman.Co.Core.Models;
using Zave.Torbat.Siman.Co.Core.ResponseModels;

namespace Zave.Torbat.Siman.Co.Presentation.Interfaces
{
    public interface IPhoneVerificationPresenter:IPresentation<IPhoneVerificationView>
    {
        string DecryptToken(string tokenBack, string imeiCode);
        void VerifyPhoneNumber(string verificationCode, string originalToken);
        void StartPhoneVerification(string phoneNumber, string originalToken);
        void LogOut();
        void VerificationDoneInView(string token);
        Task<string> GetAccessTokenAsync();
    }
}
