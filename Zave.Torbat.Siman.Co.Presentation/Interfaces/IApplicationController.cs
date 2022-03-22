using System.Threading.Tasks;
using Zave.Torbat.Siman.Co.Core;
using Zave.Torbat.Siman.Co.Core.Models;
using Zave.Torbat.Siman.Co.Core.Services;

namespace Zave.Torbat.Siman.Co.Presentation.Interfaces
{
    public interface IApplicationController
    {
        string FullName { get; set; }
        string CardNumber { get; set; }
        IAuthenticationService AuthenticationService { get; }
        IEncryptService EncryptService { get; }
        IUserDataService UserDataService { get; }
       // IPushNotifyService PushNotifyService { get; }
        IApiService ApiService { get; }
        void RunLoginView(object context);
        void RunMainPageView(TruckViewModel truckViewModelObject,object context);
        void RunPhoneVerificationView(string userObjectPhoneNumber,object context);
        Task LogOutUser(object context);
        Task<string> GetAccessTokenAsync(object context);
        bool IsGooglePlayServicesAvailable();
        void RunTakeLoadView(object context);
        void RunLoadInfoView(object context);
        void SetTakeLoadEnableTime();
        Task<string> GetTakeLoadEnableTime();
    }
}
