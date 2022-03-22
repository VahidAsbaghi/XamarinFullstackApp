using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using Zave.Torbat.Siman.Co.Core.Models;
using Zave.Torbat.Siman.Co.Core.ResponseModels;

namespace Zave.Torbat.Siman.Co.Core.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IApiService _apiService;

        public UserDataService(IAuthenticationService authenticationService,IApiService apiService)
        {
            _authenticationService = authenticationService;
            _apiService = apiService;
        }
        public TruckViewModel GetUserProfile(string token)
        {
            var userJson = _authenticationService.GetUser(token);
            var user = JsonConvert.DeserializeObject<TruckViewModel>(userJson);
            return user;
        }

        public MainPageDataResponseModel GetMainPageDataModel(string token)
        {
            var response = _apiService.GetMainPageData(token);
            var mainPageDataResponse = JsonConvert.DeserializeObject<MainPageDataResponseModel>(response.Content);
            return mainPageDataResponse;
        }
    }
}
