using RestSharp;
using Zave.Torbat.Siman.Co.Core.Models;
using Zave.Torbat.Siman.Co.Core.ResponseModels;

namespace Zave.Torbat.Siman.Co.Core.Services
{
    public interface IUserDataService
    {
        TruckViewModel GetUserProfile(string token);
        MainPageDataResponseModel GetMainPageDataModel(string token);
    }
}