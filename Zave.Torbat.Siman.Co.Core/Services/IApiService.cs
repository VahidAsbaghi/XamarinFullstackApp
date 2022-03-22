using System.Threading.Tasks;
using RestSharp;
using Zave.Torbat.Siman.Co.Core.Models;
using Zave.Torbat.Siman.Co.Core.RequestModels;
using Zave.Torbat.Siman.Co.Core.ResponseModels;

namespace Zave.Torbat.Siman.Co.Core.Services
{
    public interface IApiService
    {
        IRestResponse GetLogin(Credentials credentials);
        IRestResponse GetUser(string token);
        Task<IRestResponse> ConfirmPhoneNumber(TokenMobileVerificationRequestModel verificationTokenModel, string token);
        Task<IRestResponse> StartPhoneConfirmation(string phoneNumber, string originalToken);
        Task<IRestResponse> LogOut(string originalToken);
        IRestResponse GetMainPageData(string token);
        IRestResponse GetCurrentPosition(string token);
        Task<IRestResponse> GetTownsAsync(string token);
        Task<IRestResponse> GetLoadsDataAsync(string token, string selectedTowName);
        Task<IRestResponse> TakeTurnAsync(string token);
        Task<IRestResponse> CancelTurnAsync(string token);
        Task<IRestResponse> GetPlaques(string token);
        Task<IRestResponse> GetSelectedLoadInfo(string token);
        Task<IRestResponse> LoadSelected(string selectedLoad,string token);
        Task<IRestResponse> GetTakeLoadPermission(string accessToken);
    }
}